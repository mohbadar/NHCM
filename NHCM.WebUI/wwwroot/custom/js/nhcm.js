var clean = window.clean = {};
(function () {
    clean = {
        init: function (opt) {
            var self = this;
            var page = {};
            page.el = $('body');
            new clean.page(page);
        },
        data: {
            get: function (opt) {
                $.extend(opt, { type: 'get' });
                return clean.data.ajax(opt);
            },
            post: function (opt) {
                $.extend(opt, { type: 'post' });
                return clean.data.ajax(opt);
            },
            json: {
                /**
                 * Initialize the JSON support.
                 */
                init: function () {
                    if (!window.JSON2) return;
                    // In case JSON is supported natively by the browser
                    if (!window.JSON) {
                        window.JSON = JSON2;
                        window.JSON.parse = function (data) { return (new Function("return " + data))(); };
                    }
                    // Native JSON in firefox converts dates using timezones, so we use a custom formatter
                    window.JSON.stringify = JSON2.stringify;
                },

                /**
                 * Read JSON data from the given string by by parsing it returning a javascript value.
                 * @param {string} s
                 */
                read: function (s) { return JSON.parse(s); },

                /**
                 * Converts the given value into string containing data in JSON format.
                 * @param {Object} v
                 */
                write: function (v) { return JSON.stringify(v); }
            },
            ajax: function (opt) {
                var url = opt.url || opt.service;
                if (!opt.url) $.extend(opt, { url: url });
                var complete1 = opt.complete, success1 = opt.success, ui = clean.widget;
                opt.contentType = opt.contentType === undefined ? 'application/json; charset=utf-8' : opt.contentType;
                opt.dataType = opt.dataType === undefined ? 'json' : opt.dataType; // we may require to get list
                return $.ajax($.extend(opt, {
                    timeout: 300000,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    complete: function (xhr, status) {
                        if (status === 'timeout')
                            return;
                        if (xhr.status === 400 || xhr.status === 404)
                            // ui.error("Invalid request: " + opt.url);
                            if (complete1)
                                complete1(xhr);
                    },
                    success: function (msg) {
                        if (msg == null) {
                            ui.error("درخواست اشتباه میباشد", "سیستم درخواست شما را پذیرفته نتوانست لطفاً با مسؤلین تخنیکی صحبت نمائید");
                        }
                        if (success1)
                            success1(msg);
                    },
                    error: function (xhr, status, e) {
                        if (status == null) {
                            ui.error("Web API not accessible");
                        } else if (status === 'timeout') {
                            ui.error('timeout');
                        } else if (status == "parseerror") {
                            ui.error("The url {0} did not respond.".replace('{0}', opt.url));
                        } else if (status.toLowerCase() == "abort") {
                            ui.error('', '');
                        } else if (xhr.getResponseHeader("jsonerror")) {
                            var msg = xhr.responseText;
                            ui.error(msg.Message);
                        } else {
                            ui.error((status ? status + " " : "") + (e || "") || xhr.responseText);
                        }
                    }
                }));
            }
        },
        widget: {
            message: function (type, msg, body) {
                if (!msg) return;
                $.jGrowl(body, {
                    header: msg,
                    theme: type
                });
            },
            warn: function (msg, body) { clean.widget.message('alert-styled-left  bg-warning', msg, body) },
            error: function (msg, body) { clean.widget.message('bg-danger-400 alert-styled-left alert-styled-custom', msg, body) },
            success: function (msg, body) { clean.widget.message('bg-success-700 alert-styled-left alert-styled-custom', msg, body) }
        }
    }
})();

var clean = window.clean = window.clean || {};
(function () {
    clean.page = function (opt) {
        this.opt = opt = opt || {};
        this.el = opt.el;
        this.mainform = {};
        this.subforms = [];
        this.name = opt.name || 'default';
        this.components = this.el.find('.page-component');
        this.init(this.el);
    }
    clean.page.prototype = {
        init: function (opt) {
            var self = this;
            self.construct();
        },
        construct: function (opt) {
            var self = this;
            self.components.each(function (index) {
                this.el = $(this);
                this.page = self;
                if (this.el.attr('type') == 'form' && this.el.hasClass('main-form')) {
                    self.mainform = new clean[this.el.attr('type')](this);
                }
                else if (this.el.attr('type') == 'form' && this.el.hasClass('sub-form')) {
                    var sub = new clean[this.el.attr('type')](this);
                    self.subforms.push(sub);
                }
                else {
                    new clean[this.el.attr('type')](this);
                }
            });
        }
    };
})();

var clean = window.clean = window.clean || {};
(function () {
    clean.form = function (opt) {
        this.opt = opt = opt || {};
        this.el = opt.el;
        this.page = opt.page;
        this.prefix = this.el.attr('prefix') || "ux";
        this.record = {};
        this.master = {};
        this.actions = this.el.find('.div-form-control [action]');
        this.fields = [];
        this.grid = {};
        this.grid.template = this.el.find('.form-grid');
        this.grid.table = this.el.attr('id').replace('dv', 'gv');
        this.grid.cols = [];
        this.init(this.el);
    }
    clean.form.prototype = {
        init: function (opt) {
            var self = this;
            self.construct();
            //Registering the clean form actions -- Save -- Search -- New
            this.actions.bind('click', function () {
                var act = $(this).attr('action');
                if (self[act]) self[act]();
                return false;
            });
        },
        getfields: function () {
            var self = this;
            self.fields = self.el.find(':text, :radio, :checkbox, input:hidden, select, textarea').not(":button, :submit");
        },
        construct: function () {
            var self = this;
            self.getfields();
            self.el.find('select').select2({
                placeholder: "--",
                allowClear: true
            });
            // Configuring the datepicker on inputs

            $('.Shamsi').each(function () {
                var el = $(this);
                var sib = el.attr('sibling');
                el.MdPersianDateTimePicker({
                    targetTextSelector: '#' + el.attr('id'),
                    targetDateSelector: '#' + sib,
                    dateFormat: 'yyyy-MM-dd',
                    isGregorian: false,
                    enableTimePicker: false
                });
            });

            $('.Miladi').each(function () {
                var el = $(this);
                var sib = el.attr('sibling');
                el.MdPersianDateTimePicker({
                    targetTextSelector: '#' + sib,
                    targetDateSelector: '#' + el.attr('id'),
                    dateFormat: 'yyyy-MM-dd',
                    isGregorian: true,
                    toPersian: true,
                    enableTimePicker: false
                });
            });

            $(self.grid.template.find('thead').find('th')).each(function (index) {
                self.grid.cols.push($(this).attr('colname'));
            });
            $(self.grid.template).find('table').addClass('table table-bordered table-hover datatable-highlight').attr('id', self.grid.table);
            self.el.parents('.panel').append(self.grid.template);

            if (self.el.find('.img-uploader')) {

                var croppicContainerModalOptions = {
                    uploadUrl: '/Recruitment/Person/Upload',
                    cropUrl: '/Recruitment/Person/Crop',
                    modal: true,
                    imgEyecandy: true,
                    doubleZoomControls: false,
                    rotateControls: false,
                    imgEyecandyOpacity: 0.4,
                    loaderHtml: '<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> ',
                    onBeforeImgUpload: function () { console.log('onBeforeImgUpload') },
                    onAfterImgUpload: function () { console.log('onAfterImgUpload') },
                    onImgDrag: function () { console.log('onImgDrag') },
                    onImgZoom: function () { console.log('onImgZoom') },
                    onBeforeImgCrop: function () { console.log('onBeforeImgCrop') },
                    onAfterImgCrop: function () { console.log('onAfterImgCrop') },
                    onReset: function () { console.log('onReset') },
                    onError: function (errormessage) { console.log('onError:' + errormessage) }
                }
                var cropperHeader = new Croppic(self.prefix + 'Photo', croppicContainerModalOptions);
            }
        },
        save: function () {
            var self = this;
            self.el.find('.auto-gen-hidden').remove();
            var validation = self.validation(self.el);
            if (self.el.valid()) {
                var path = self.el.attr('id');
                if (self.el.hasClass('sub-form')) {
                    self.el.append("<input type='hidden' class='auto-gen-hidden' id='" + self.prefix + self.el.attr('parentcol') + "' value = '" + self.page.mainform.record.id + "' /> ");
                    self.getfields();
                }
                path = '/' + path.substring(path.indexOf("_") + 1).replace('_', '/') + '/save';
                var data = {};
                self.fields.each(function () {
                    var fld = $(this);
                    var col = fld.attr('id').substring(self.prefix.length);
                    if (col.indexOf('_auto') === -1)
                        Object.defineProperty(data, col.toString(), { value: fld.val().toString(), enumerable: true });
                });
                clean.data.post({
                    async: false, url: path, data: clean.data.json.write(data), dataType: 'json',
                    success: function (msg) {
                        if (msg.status > 0) {
                            var list = msg.data.list;
                            clean.widget.success(msg.text, msg.description);
                            self.bindtogrid(list);
                        }
                        else {
                            clean.widget.warn(msg.text, msg.description);
                        }
                    }
                });
            }
        },
        search: function (r) {
            var self = r || this;
            var path = self.el.attr('id');
            path = '/' + path.substring(path.indexOf("_") + 1).replace('_', '/') + '/search';

            self.el.find('.auto-gen-hidden').remove();
            if (self.el.hasClass('sub-form')) {
                self.el.append("<input type='hidden' class='auto-gen-hidden search' id='" + self.prefix + self.el.attr('parentcol') + "' value = '" + self.page.mainform.record.id + "' /> ");
                self.getfields();
            }
            var data = {};
            if (r) {
                data = self.record;
            }
            else {
                self.el.find('input.search, textarea.search, select.search').each(function () {
                    var fld = $(this), col = fld.attr('id').substring(self.prefix.length);
                    if (col.indexOf('_auto') === -1)
                        Object.defineProperty(data, col.toString(), { value: fld.val().toString(), enumerable: true });
                });
            }
            clean.data.post({
                async: false, url: path, data: clean.data.json.write(data), dataType: 'json',
                success: function (msg) {
                    var list = msg.data.list;
                    if (r) {
                        self.bindtoform(list[0]);
                    }
                    else {
                        self.bindtogrid(list);
                    }
                }
            });
        },
        new: function (opt) {
            var self = this;
            self.fields.each(function () {
                var fld = $(this), v = "";
                fld.val(null).change();
            });
            self.el.find('.auto-gen-hidden').remove();
            self.getfields();
        },
        test: function () {
            var self = this;
        },
        configure: function (opt) {
        },
        fetch: function (r) {
            var self = this;
            self.search(r);
        },
        bindtoform: function (d) {
            var self = this;
            self.record = d;
            for (var key in d) {
                var control = $('#' + (self.prefix + key).toLowerCase());
                control.val(d[key]).change();
                if (control.hasClass("Miladi")) {
                    control.MdPersianDateTimePicker('setDate', new Date(d[key]));
                }
                if (key == 'id') {
                    if (!self.el.find($('#' + self.prefix + key)).length) {
                        self.el.append("<input type='hidden' class='auto-gen-hidden' id='" + self.prefix + "id' value='" + d[key] + "' />");
                        self.getfields();
                    }
                }
            }
            $('.sub-form').each(function () {
                var form = $(this);
                if (form.attr('parent') == self.el.attr('id')) {
                    $.each(self.page.subforms, function (index, sub) {
                        if (sub.el.attr('id') == form.attr('id')) {
                            sub.new();
                            sub.search();
                        }
                    });
                }
            });
        },
        bindtogrid: function (d) {
            var self = this;
            var row = "";
            var rowclick = $('#' + self.grid.table).attr('bindonclick') ? 'fetch-record' : '';
            $('#' + self.grid.table).DataTable().clear().draw().destroy();
            $.each(d, function (ind, ob) {
                var column = "";
                for (var i = 0; i < self.grid.cols.length; i++) {
                    var colname = self.grid.cols[i].toLowerCase();
                    for (var key in ob) {
                        if (key.toLowerCase() == colname) {
                            column = column + "<td col='" + key.toLowerCase() + "'>" + ob[key] + "</td>";
                        }
                    }
                }
                row = row + "<tr role='row' class='" + rowclick + "' data='" + ob.id + "'>" + column + "</tr>";
            });

            $('#' + self.grid.table).find('tbody').empty().html(row);
            $('#' + self.grid.table).DataTable({
                "paging": false,
                "ordering": false,
                "info": false,
                "filter": false,
                autoWidth: true,
                scrollY: 150
            });

            $('#' + self.grid.table).find('.fetch-record').click(function () {
                self.record = {};
                self.record.id = $(this).attr('data');
                self.fetch(self);
            });
        },
        validation: function () {
            $(this.el).validate({
                ignore: 'input[type=hidden], input[type=file] .select2-input',
                errorClass: 'validation-error-label',
                successClass: 'validation-valid-label',
                highlight: function (element, errorClass) {
                    $(element).removeClass(errorClass);
                },
                unhighlight: function (element, errorClass) {
                    $(element).removeClass(errorClass);
                },
                errorPlacement: function (error, element) {
                    if (element.parents('div').hasClass('input-group')) {
                        error.insertBefore(element.parent());
                    }
                    else if (element.siblings('div').hasClass('select2-container')) {
                        error.insertAfter(element.siblings('label'));
                    }
                    else {
                        error.insertBefore(element);
                    }
                },
                rules: {
                    email: {
                        email: true
                    }
                }
            });
        }
    };
}
)();

var clean = window.clean = window.clean || {};
(function () {
    clean.actionmenu = function (opt) {
        this.opt = opt = opt || {};
        this.el = opt.el;
        this.page = opt.page;
        this.name = opt.name || 'subscreens';
        this.actions = this.el.find('[action]');
        this.menus = [];
        this.init();
    }
    clean.actionmenu.prototype = {
        init: function () {
            var self = this;
            self.construct();
        },
        construct: function () {
            var self = this;
            var sidebar = $('.page-sidebar');
            if (sidebar) {
                this.el.html(sidebar);
                this.actions = self.el.find('[action]');
                this.actions.bind('click', function () {
                    var act = $(this).attr('action');
                    if (self[act]) self[act]($(this));
                    return false;
                });
            }
        },
        subscreen: function (el) {
            var self = this;
            var action = el;
            var formname = action.attr('page');
            var path = '/' + formname.substring(formname.indexOf("_") + 1).replace('_', '/') + '/Get';
            var data = {};
            if (self.page.mainform.record.id) {
                clean.data.post({
                    async: false, url: path, data: clean.data.json.write(data), dataType: 'html',
                    success: function (msg) {
                        var html = msg;
                        $('.dependent-screens').html(html);
                        var subform = {};
                        subform.el = $('#' + formname);

                        subform.page = self.page;
                        if (subform.el.hasClass('page-component')) {
                            if (subform.el.attr('type') == 'form' && subform.el.hasClass('sub-form')) {
                                var sub = new clean[subform.el.attr('type')](subform);
                                self.page.subforms.push(sub);
                                self.page.mainform.el.parents('.panel').find('.main-form-details').hide();
                                //self.page.mainform.el.find('.main-form-details').hide();
                            }
                        }
                    }
                });
            }
            else {
                clean.widget.error('فورم اصلی خالی میباشد', 'لطفاً برای اینکه صفحه های فرعی را مشاهده نمائید، ریکارد فورم اصلی را مشخص سازید');
            }
        }
    };
})();


// Requires JQuery
// Configure the side bar of an screen by passing values for Sidebar container and the id of div where partials to be loaded.



function configureSideBar(sidebar, pageLanding, parent) {        //Get all anchors having attribute "page"
    var anchorsContainer = $('#' + sidebar.toString()).find("a[page]");
    $.each(anchorsContainer, function () {
        var el = $(this);
        el.on('click', function () {
            if (parent !== "") {
                $('#' + pageLanding.toString()).load('/' + el.attr("page").toString() + '/' + parent.toString());
            }

            else {
                $('#lblMessage').html("معلومات فورم اصلی ثبت نمیباشد");
            }

        });
    });
}



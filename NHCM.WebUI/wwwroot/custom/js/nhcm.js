$(document)
    .ajaxStart(function () {
        $("#overlay").show();
    })
    .ajaxStop(function () {
        $("#overlay").hide();
    });

var clean = window.clean = {};
(function () {
    clean = {
        init: function (opt) {
            var self = this;
            var page = {};
            page.el = $('body');
            new clean.page(page);
        },
        isEmpty: function (value) {
            return typeof value == 'string' && !value.trim() || typeof value == 'undefined' || value === null;
        },
        format: function (s, row, indexes) {
            if (!indexes) return s;
            // get each key of indexes and replace with coresponding row value
            if (row instanceof Array) // row: [1, "Ahmad", "CEO", "21", ...]
                for (key in indexes) {
                    var index = indexes[key];
                    //if (typeof index == "number") index = {index:index};
                    if (!isNaN(index)) index = { index: index };
                    var val = row[index.index]; val = val == null ? "" : this.accounting(val, key);
                    if (index.fn) val = val[0];
                    s = s.replace(new RegExp("{" + key + "}", 'g'), val) // replace all
                }
            else // row: {ID:1, Name:"Ahmad", "Position":"CEO", "Age": 21, ...}
                for (key in indexes) {
                    var val = row[key]; val = val == null ? "" : this.accounting(val, key) /*val*/;
                    if (typeof indexes[key] !== "number" && key.fn == "first") { val = val[0]; key = key.index };
                    s = s.replace(new RegExp("{" + key + "}", 'g'), row[key]) // replace all
                }
            return s;
        },
        accounting: function (n, key) {
            if (key && key.length >= 2 && (key.substr(key.length - 2, 2).toLowerCase() == "id" || key.substr(key.length - 4, 4).toLowerCase() == "code" || key.substr("mobile") > -1 || key.substr("phone") > -1)) return n;
            if (!$.isNumeric(n)) return n;
            if ((n + "").length > 3 && (n + "").substr(0, 1) == "0")
                return n;

            return n.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
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

                    type : opt.type,
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
                else if (this.el.attr('type') == 'actionmenu') {
                    var side = $('.page-sidebar');
                    if (side.length && side.attr('display') == 'false') {
                        $('.sidebar').parent().remove();
                        $('.main-content').addClass('col-md-offset-1').removeClass('pull-right');
                    }
                    else {
                        new clean[this.el.attr('type')](this);
                    }
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
        this.path = "";
        this.page = opt.page;
        this.parent = opt.parent || {};
        this.prefix = this.el.attr('prefix') || "ux";
        this.record = {};
        this.uploaders = {};
        this.uploaders.photo = {};
        this.uploaders.document = {};
        this.master = {};
        this.tazkira = {};
        this.actions = this.el.find('.div-form-control [action]');
        this.fields = [];
        this.modal = {};
        this.grid = {};
        this.grid.template = this.el.find('.form-grid');
        this.grid.table = this.el.attr('id').replace('dv', 'gv');
        this.grid.cols = [];
        this.validationrule = {};
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
        getactions: function () {
            var self = this;
            self.actions = this.el.find('.div-form-control [action]');
        },
        getfields: function () {
            var self = this;
            self.fields = self.el.find(':text, :radio, :checkbox, input:hidden, select, textarea').not(":button, :submit");
            var filtered = self.fields.filter(function (item, index, arry) {
                if ($(self.fields[item]).attr('id').startsWith(self.prefix)) return self.fields[item];
            });
            self.fields = filtered;
        },
        construct: function () {
            var self = this;
            var path = self.el.attr('id');
            self.path = '/' + path.substring(path.indexOf("_") + 1).replace('_', '/');

            if (self.el.attr('attachment')) {
                self.el.find('.actions').append(' <button type="button" class="btn btn-primary" action="attach" style="float:left;"><i class="icon-attachment position-right"></i>اسناد و ضمایم </button>');
                self.getactions();
            }

            if (self.el.hasClass('sub-form')) {
                if (!$.isEmptyObject(self.el.find('#' + self.prefix + self.el.attr('parentcol')))) {
                    self.el.append("<input type='hidden' class='auto-gen-hidden search' id='" + self.prefix + self.el.attr('parentcol') + "' value = '" + self.parent.record.id + "' /> ");
                }
            }
            self.getfields();

            self.el.find('select').select2({
                placeholder: "--",
                allowClear: true
            });
            self.el.find('select').on('change', function (evt) {
                $thisVal = $(this).val();
                if ($thisVal != '') {
                    setTimeout(function () {
                        self.el.valid();
                    }, 100);
                }
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

            self.el.find('.national-id').each(function () {
                var opt = {};
                opt.el = $(this).find('.national-id-input');
                opt.parent = $(this).parent();
                opt.form = self;
                self.tazkira = new clean.Tazkira(opt);
            });


            $(self.grid.template.find('thead').find('th')).each(function (index) {
                self.grid.cols.push($(this).attr('colname'));
            });
            $(self.grid.template).find('table').addClass('table table-bordered table-hover').attr('id', self.grid.table);
            self.el.parents('.panel').append(self.grid.template);

            if (self.el.find('.img-uploader').length) {
                var ouput = self.el.find('.img-uploader').siblings('.output').attr('id');
                var croppicContainerModalOptions = {
                    uploadUrl: self.path + '/Upload',
                    cropUrl: self.path + '/Crop',
                    downloadUrl: self.path + '/Download',
                    outputUrlId: ouput,
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
                self.uploaders.photo = new Croppic(self.prefix + 'Photo', croppicContainerModalOptions);
            }
            if (self.el.find('.file-attachment').length) {
                var el = self.el.find('.file-attachment');
                self.initiateFileUpload(el);
            }

            self.validationrule = self.validation();
        },
        initiateFileUpload: function (e) {
            var self = this;
            self.uploaders.document = e.fileinput({
                uploadUrl: 'adsfasdfadfaf',
                showCancel: false,
                browseLabel: '',
                browseClass: 'btn btn-primary btn-icon',
                removeLabel: '',
                uploadLabel: 'aaa',
                browseIcon: '<i class="icon-plus22"></i> ',
                removeClass: 'btn btn-remove btn-icon',
                removeIcon: '<i class="icon-cancel-square"></i> ',
                layoutTemplates: {
                    caption: '<div tabindex="-1" class="form-control file-caption {class}">\n' + '<span class="icon-file-plus kv-caption-icon"></span><div class="file-caption-name"></div>\n' + '</div>'
                },
                initialCaption: "فایل انتخاب نگردیده"
            }).on('fileselect', function (event, numFiles, label) {
                setTimeout(function () {
                    self.el.valid();
                }, 100);
                var formData = new FormData(self.el[0]);
                $.ajax({
                    url: self.path + '/Upload',
                    data: formData,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    context: document.body,
                    cache: false,
                    contentType: false,
                    processData: false,
                    type: 'POST'
                }).always(function (data) {
                    if (data.status > 0) {
                        if (!self.el.find($('#' + self.prefix + 'path')).length)
                            self.el.append("<input type='hidden' class='auto-gen-hidden' id='" + self.prefix + "path' value='" + data.url + "' />");
                        else
                            self.el.find($('#' + self.prefix + 'path')).val(data.url);
                        self.getfields();
                        clean.widget.success(data.text, data.description);
                        self.el.find('.file-caption-name').removeClass('error-upload');
                    }
                    else {
                        self.el.find('.file-caption-name').addClass('error-upload');
                        clean.widget.error(data.text, data.description);
                    }
                    self.el.find('.file-caption-name').html(data.text + "، " + data.description);
                });
            });
        },
        save: function () {
            var self = this;
            if (self.el.hasClass('sub-form')) {
                if (!self.el.find($('#' + self.prefix + self.el.attr('parentcol'))).length) {
                    self.el.append("<input type='hidden' class='auto-gen-hidden search' id='" + self.prefix + self.el.attr('parentcol') + "' value = '" + self.parent.record.id + "' /> ");
                }
                self.getfields();
            }

            self.getfields();
            var _tazkira = false;
            if (!$.isEmptyObject(self.tazkira)) {
                _tazkira = self.tazkira.validate();
                if (_tazkira) {
                    $('#uxnid').val(self.tazkira.val());
                }
            }
            else {
                _tazkira = true;
            }
            self.fields.each(function () {
                var fld = $(this);
                var col = fld.attr('id').substring(self.prefix.length);
            });
            var _photovalid = false;
            if (self.uploaders.photo.hasOwnProperty('options')) {
                _photovalid = self.uploaders.photo.validate();
                if (!_photovalid) {
                    clean.widget.error('عکس اپلود نگردیده', 'کاربر محترم، لطفاً عکس کارمند را انتخاب نماید. دیتا کارمندان بدون عکس ثبت نمیگردد');
                }
            }
            else {
                _photovalid = true;
            }
            if (self.el.valid() && _photovalid && _tazkira) {
                var path = self.path + '/save';
                var data = {};
                self.fields.each(function () {
                    var fld = $(this);
                    var col = fld.attr('id').substring(self.prefix.length);
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
            var path = self.path + '/search';

            if (self.el.hasClass('sub-form')) {
                if (!self.el.find($('#' + self.prefix + self.el.attr('parentcol'))).length) {
                    self.el.append("<input type='hidden' class='auto-gen-hidden search' id='" + self.prefix + self.el.attr('parentcol') + "' value = '" + self.parent.record.id + "' /> ");
                }
                self.getfields();
            }

            var data = {};
            if (r) {
                data = self.record;
            }
            else {
                self.el.find('input.search, textarea.search, select.search').each(function () {
                    var fld = $(this), col = fld.attr('id').substring(self.prefix.length);
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
                var fld = $(this);
                if (fld.attr('placeholder', 'درج نگردیده')) fld.attr('placeholder', '');

                if (!fld.attr('default'))
                    fld.val(null).change();
            });
            self.el.find('.auto-gen-hidden').remove();
            if (!$.isEmptyObject(self.uploaders.photo)) {
                self.uploaders.photo.destroy();
                self.uploaders.photo.init();
            }
            if (!$.isEmptyObject(self.uploaders.document)) {
                if (self.el.find('.file-attachment').length) {
                    self.el.find('.file-attachment').attr('required', 'required');
                    self.el[0].reset();
                }
            }
            self.getfields();
        },
        test: function () {
            alert('test');
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
            self.new();
            for (var key in d) {
                var control = $('#' + (self.prefix + key).toLowerCase());
                if (clean.isEmpty(d[key]))
                    control.attr('placeholder', 'درج نگردیده')
                else
                    if (!control.attr('default'))
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
                if (key == 'nid') {
                    self.tazkira.val(d[key]);
                }
                if (key == 'photoPath') {
                    self.uploaders.photo.bind(d[key]);
                }
                if (key == 'path') {
                    if (!self.el.find($('#' + self.prefix + key)).length)
                        self.el.append("<input type='hidden' class='auto-gen-hidden' id='" + self.prefix + "path' value='" + d[key] + "' />");
                    self.el.find('.file-attachment').removeAttr('required');
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
        download: function (e) {
            var self = this;
            var file = {};


            file.Name = e;
            var xhr = new XMLHttpRequest();

            xhr.open('POST', self.path + '/Download', true);

            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
            xhr.setRequestHeader("Content-Type", 'application/json; charset=utf-8');
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var blob = new Blob([xhr.response], {
                        type: xhr.getResponseHeader("Content-Type")
                    });
                    var url = window.URL.createObjectURL(blob);
                    window.open(url, url, "directories=0,titlebar=0,toolbar=0,location=0,status=0,menubar=0,scrollbars=no,resizable=no,width=400,height=400");

                }
            }
            xhr.responseType = "arraybuffer";
            xhr.send(JSON.stringify(file));
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
                            if (colname != 'path') {
                                var va = ob[key];
                                if (clean.isEmpty(ob[key]))
                                    va = 'درج نگردیده';
                                column = column + "<td col='" + key.toLowerCase() + "'>" + va + "</td>";
                            }
                            else {
                                var temp = '<button type="button" downloadpath="$path" class="btn-link download-on-click"><i class="icon-download position-right"></i>دریافت فایل</button>'
                                column = column + "<td col='" + key.toLowerCase() + "'>" + temp.replace('$path', ob[key]) + "</td>";
                            }
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
            $('#' + self.grid.table).find('.download-on-click').click(function () {
                self.download($(this).attr('downloadpath'));
            });
            self.bindtoform(d[0]);


        },

        attach: function () {
            var self = this;
            if (!$.isEmptyObject(self.record)) {
                path = "/Document/Document/Get";
                var modalid = self.prefix + self.el.attr('id') + '_Modal';
                if ($.isEmptyObject(self.modal)) {
                    var modal = '<div id="' + modalid + '" class="modal fade"><div class="modal-dialog modal-lg"><div class="modal-content"></div></div></div>';
                    var close = '<button type="button" class="btn btn-link close-bttn" data-dismiss="modal"><i class="icon-close2 position-right"></i>صرف نظر</button>'
                    $('.dependent-screens').append(modal);
                    self.modal = $('#' + modalid);
                    var data = {};
                    clean.data.post({
                        async: false, url: path, data: clean.data.json.write(data), dataType: 'html',
                        success: function (msg) {
                            var html = msg;
                            self.modal.find('.modal-content').html(html);
                            var subform = {};
                            subform.el = $('#' + $(html).find('form').attr('id'));
                            subform.el.attr('parent', self.el.attr('id'));
                            var items = self.path.split('/');
                            subform.el.append("<input type='hidden'  id='" + subform.el.attr('prefix') + "module' value='" + items[1] + "' default='" + items[1] + "' />");
                            subform.el.append("<input type='hidden'  id='" + subform.el.attr('prefix') + "item' value='" + items[2] + "' default='" + items[2] + "' />");
                            subform.el.find('.actions').append(close);
                            subform.parent = self;
                            subform.page = self.page;
                            if (subform.el.hasClass('page-component')) {
                                if (subform.el.attr('type') == 'form' && subform.el.hasClass('sub-form')) {
                                    var sub = new clean[subform.el.attr('type')](subform);
                                    self.page.subforms.push(sub);
                                }
                            }
                        }
                    });
                }
                self.modal.modal();
            }
            else {
                var title = 'فورم $formname خالی میباشد';
                var des = 'برای اینکه اسناد و ضمایم مربوط به فورم $formname را مشاهده نمائید، لطفاً ریکارد این فورم را مشخص سازید';
                var heading = self.el.parents('.panel-body').siblings('.panel-heading').find('h1');
                title = title.replace('$formname', $(heading).text());
                des = des.replace('$formname', $(heading).text());
                clean.widget.error(title, des);
            }
        },
        others: function (v) {
           //var self = r || this;
            var self = this;
            var path = self.path + '/' + v.name;
            var data = {};
            self.fields.each(function () {
                var fld = $(this); 
                var col = fld.attr('id').substring(self.prefix.length);
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
        },
        next: function () {
            var self = this;
            var v = {};
            v.name = 'next';
            self.others(v);
        },
        previous: function () {
            var v = {};
            v.name = 'previous';
            self.others(v);
        },
        validation: function () {
            var self = this;
            var validator = $(self.el).validate({
                ignore: 'input[type=hidden], input[type=file] .select2-input',
                errorClass: 'validation-error-label',
                successClass: 'validation-valid-label',
                highlight: function (element, errorClass) {
                    $(element).addClass("hrmis-error");
                    if ($(element).hasClass('file-attachment')) {
                        $(element).parents('.input-group').find('.form-control').addClass('hrmis-error');
                    }
                },
                unhighlight: function (element, errorClass) {
                    setTimeout(function () {
                        $(element).removeClass("hrmis-error");
                        if ($(element).hasClass('file-attachment')) {
                            $(element).parents('.input-group').find('.form-control').removeClass('hrmis-error');
                        }
                    }, 50);
                },
                errorPlacement: function (error, element) {
                    if (element.parents('div').hasClass('input-group') && element.siblings('span').hasClass('input-group-addon')) {
                        error.insertBefore(element.parent());
                    }
                    else if (element.siblings('div').hasClass('select2-container')) {
                        error.insertAfter(element.siblings('label'));
                    }
                    else if (element.hasClass('file-attachment')) {
                        error.insertAfter(element.parents('.file-parent').find('label'));

                    }
                    else {
                        error.insertBefore(element);
                    }
                },
                rules: {
                    email: {
                        email: true
                    },
                    SerialNumber: {
                        digits: true,
                        maxlength: 15
                    },
                    Juld: {
                        maxlength: 12
                    },
                    Page: {
                        digits: true,
                        maxlength: 2
                    },
                    No: {
                        digits: true,
                        maxlength: 1
                    }

                }
            });
            return validator;
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
            if (!$.isEmptyObject(self.page.mainform.record)) {

                clean.data.get({

                    async: false, url: path, data: clean.data.json.write(data), dataType: 'html',
                    success: function (msg) {
                        var html = msg;
                        $('.dependent-screens').html(html);
                        var subform = {};
                        subform.el = $('#' + formname);
                        subform.parent = self.page.mainform;
                        subform.page = self.page;
                        if (subform.el.hasClass('page-component')) {
                            if (subform.el.attr('type') == 'form' && subform.el.hasClass('sub-form')) {
                                var sub = new clean[subform.el.attr('type')](subform);
                                self.page.subforms.push(sub);
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

var clean = window.clean = window.clean || {};
(function () {
    clean.Tazkira = function (opt) {
        this.el = opt.el;
        this.sib = $('#' + this.el.attr('sibling'));
        this.sib.val = '';
        this.form = opt.form;
        this.row = opt.parent;
        this.template = "<div class='col-md-2 col-sm-12 col-xs-12 pull-right tazkira-group $g-class'><div class='form-group'><label class='text-bold'><span class='text-danger pull-left'>&nbsp;*</span>$Label</label><input id='$id' name='$name' class='form-control alt-tazkira' required/></div></div>";
        this.serialNo = {};
        this.juld = {};
        this.page = {};
        this.No = {};
        this.init();

    };
    clean.Tazkira.prototype = {
        init: function () {
            var self = this;

            var sn = self.template.replace('$Label', 'نمبر سند هویت').replace('$id', 'sn').replace('$g-class', 'always').replace('$name', 'SerialNumber');
            self.row.append(sn);
            self.serialNo = $('#sn');

            var jd = self.template.replace('$Label', 'جلد').replace('$id', 'jd').replace('$g-class', 'old').replace('$name', 'Juld');
            self.row.append(jd);
            self.juld = $('#jd');

            var pg = self.template.replace('$Label', 'نمبر صفحه').replace('$id', 'pg').replace('$g-class', 'old').replace('$name', 'Page');
            self.row.append(pg);
            self.page = $('#pg');

            var no = self.template.replace('$Label', 'نمبر ثبت').replace('$id', 'no').replace('$g-class', 'old').replace('$name', 'No');;
            self.row.append(no);
            self.No = $('#no');

            self.sib.change(function () {
                var v = $(this).find("option:selected").text().trim();
                self.sib.val = v;
                self.changeselect(v);
            });

            $('.old').hide();
        },
        changeselect: function (v) {
            var self = this;
            if (v == 'تذکره ورقی') {
                $('.old').show();
                $('.alt-tazkira').val("");
            }
            else {
                $('.old').hide();

            }

        },
        getExpr: function (col) {
            var v = "{S:'%" + (this.serialNo.val().trim() != "" ? this.serialNo.val().trim() : "") + "'," +
                "J:'%" + (this.juld.val().trim() != "" ? this.juld.val().trim() : "") + "'," +
                "P:'%" + (this.page.val().trim() != "" ? this.page.val().trim() : "") + "'," +
                "N:'%" + (this.No.val().trim() != "" ? this.No.val().trim() : "") + "'}";
            var expr = {};
            expr.fn = "endswith";
            expr.expr = {};
            expr.expr[col] = v;
            return expr;
        },
        validate: function () {
            if (this.sib.val == 'تذکره ورقی')
                return $('.alt-tazkira').valid();
            else
                return $('#sn').valid();
        },
        val: function (v) {
            if (v !== undefined) {
                v = v + "";
                // clear
                this.serialNo.val('');
                this.juld.val('');
                this.page.val('');
                this.No.val('');
                var v2;
                try {
                    eval('v2 = ' + v);
                    this.serialNo.val(v2.S.replace(',', ''));
                    this.juld.val(v2.J.replace(',', ''));
                    this.page.val(v2.P.replace(',', ''));
                    this.No.val(v2.N.replace(',', ''));
                }
                catch (e) {
                    v2 = v.split(" ");
                }
                // set
                return v;
            }

            var vals = [this.serialNo.val(), this.juld.val(), this.page.val(), this.No.val()];
            if (!this.serialNo.val().trim() && !this.juld.val().trim() && !this.page.val().trim() && !this.No.val().trim()) return '';
            // get
            v = clean.format("{S: '{serialNoID}', J:'{JuldID}',P:'{PageID}',N:'{NoID}'}", vals, { serialNoID: 0, JuldID: 1, PageID: 2, NoID: 3 });
            return v;
        }
    }
})();







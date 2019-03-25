using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NHCM.WebUI.Types;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.Domain.Entities;
using NHCM.Application.Lookup.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using NHCM.Application.Document.Disk.FileManager;
using NHCM.Application.Document.Disk;
using NHCM.Application.Document.Disk.Cropper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;

namespace NHCM.WebUI.Pages.Recruitment
{
    public class PersonModel : BasePage
    {
        public string SubScreens { get; set; } = "";
        private string htmltemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>
                                    ";

        private readonly IConfiguration _configuration;

        public PersonModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public async Task OnGetAsync()
        {



            ListOfLocations = new List<SelectListItem>();
            List<Location> locations = new List<Location>();
            locations = await Mediator.Send(new GetLocationQuery() { ID = null });
            foreach (Location l in locations)
                ListOfLocations.Add(new SelectListItem(l.Dari, l.Id.ToString()));

            //Get blood groups
            ListOfBloodGroups = new List<SelectListItem>();
            List<BloodGroup> bloodGroups = new List<BloodGroup>();
            bloodGroups = await Mediator.Send(new GetBloodGroupQuery() { ID = null });
            foreach (BloodGroup bloodGroup in bloodGroups)
                ListOfBloodGroups.Add(new SelectListItem(bloodGroup.Name, bloodGroup.Id.ToString()));


            // Get Genders
            ListOfGenders = new List<SelectListItem>();
            List<Gender> Genders = new List<Gender>();
            Genders = await Mediator.Send(new GetGenderQuery() { ID = null });
            foreach (Gender gender in Genders)
                ListOfGenders.Add(new SelectListItem(gender.Dari, gender.ID.ToString()));

            // Get Marital Status
            ListOfMaritalStatus = new List<SelectListItem>();
            List<MaritalStatus> maritals = new List<MaritalStatus>();
            maritals = await Mediator.Send(new GetMaritalStatusQuery() { ID = null });
            foreach (MaritalStatus maritalStatus in maritals)
                ListOfMaritalStatus.Add(new SelectListItem(maritalStatus.Name, maritalStatus.Id.ToString()));


            ListOfReligions = new List<SelectListItem>();
            List<Religion> religions = new List<Religion>();
            religions = await Mediator.Send(new GetReligionQuery() { ID = null });
            foreach (Religion religion in religions)
                ListOfReligions.Add(new SelectListItem(religion.Name, religion.Id.ToString()));


            //Get Ethnicities
            ListOfEthnicities = new List<SelectListItem>();
            List<Ethnicity> ethnicities = new List<Ethnicity>();
            ethnicities = await Mediator.Send(new GetEthnicityQuery() { ID = null });
            foreach (Ethnicity ethnicity in ethnicities)
                ListOfEthnicities.Add(new SelectListItem(ethnicity.Name, ethnicity.Id.ToString()));


            ListOfDocumentTypes = new List<SelectListItem>();
            List<DocumentType> documentTypes = new List<DocumentType>();
            documentTypes = await Mediator.Send(new GetDocumentTypeQuery() { ScreenID = 1, ID = null });
            foreach (DocumentType documentType in documentTypes)
                ListOfDocumentTypes.Add(new SelectListItem() { Text = documentType.Name, Value = documentType.Id.ToString() });


            string screen = RijndaelManagedEncryption.RijndaelManagedEncryption.DecryptRijndael(HttpContext.Request.Query["p"], "P@33word");
            int ID = Convert.ToInt32(screen);
            // int ID = Convert.ToInt32(HttpContext.Request.Query["p"]);
            try
            {
                List<Screens> screens = new List<Screens>();
                screens = await Mediator.Send(new GetSubScreens() { ID = ID });
                string listout = "";
                foreach (Screens s in screens)
                {
                    listout = listout + htmltemplate.Replace("$path", "dv_" + s.Path.Replace("/", "_")).Replace("$icon", s.Icon).Replace("$title", s.Title).Replace("$id", s.Id.ToString());
                }
                SubScreens = listout;
            }
            catch (Exception ex)
            {

            }



        }


        public async Task<IActionResult> OnPostSave([FromBody] CreatePersonCommand command)
        {
            try
            {
                // Untill application of Identity
                command.ModifiedBy = "TEST USER";
                command.CreatedBy = 10;
                command.CreatedOn = DateTime.Now;
                List<SearchedPersonModel> SaveResult = new List<SearchedPersonModel>();

                SaveResult = await Mediator.Send(command);
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = NHCM.WebUI.Types.UIStatus.Success,
                    Text = "اطلاعات مستخدم موفقانه ثبت سیستم شد",
                    Description = ""
                });
            }
            catch (Exception ex)
            {


                return new JsonResult(new UIResult()
                {
                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = ex.GetType().Equals(typeof(Application.Exceptions.ValidationException)) ? CustomMessages.ValidationException : CustomMessages.InternalSystemException,
                    Description = Convert.ToBoolean(_configuration["ShowStackTrace"]) == true ? ex.Message + ex.StackTrace : ex.Message


                });



            }
        }

        public async Task<IActionResult> OnPostSearch([FromBody]SearchPersonQuery searchQuery)
        {
          UIResult result = new UIResult();
            try
            {
                List<SearchedPersonModel> SearchedResult = new List<SearchedPersonModel>();
                SearchedResult = await Mediator.Send(searchQuery);
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = SearchedResult },
                    Status = NHCM.WebUI.Types.UIStatus.SuccessWithoutMessage,
                    Text = string.Empty,
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    // Can be changed from app settings
                    Description = ex.Message + " \n" + " StackTrace: " + ex.StackTrace
                });

            }
        }

        public async Task<IActionResult> OnPostUpload([FromQuery]IFormFile img)
        {
            FileStorage _storage = new FileStorage();
            var extension = System.IO.Path.GetExtension(img.FileName);
            // check for a valid mediatype
            if (!img.ContentType.StartsWith("image/"))
            {
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = null,
                    Status = 0,
                    Text = "فارمت عکس درست نیست",
                    // Can be changed from app settings
                    Description = ""
                });
            }
            else
            {
                //var image = Image.FromStream(img.OpenReadStream(), true, true);
                string filename = await _storage.CreateAsync(img.OpenReadStream(), extension, _configuration["Photo"]);
                var result = new
                {
                    status = "success",
                    url = filename
                };
                return new JsonResult(result);
            }
        }


        public async Task<IActionResult> OnPostCrop([FromBody] CropRequest cropmodel)
        {
            FileStorage _storage = new FileStorage();
            string filename = await _storage.Crop(cropmodel, _configuration["Photo"]);

            var result = new object();
            try
            {
                result = new
                {
                    status = "success",
                    url = filename
                };
            }
            catch (Exception e)
            {
                result = new
                {
                    status = "fail",
                    url = "",
                };
            }
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnPostDownload([FromBody] UploadedFile file)
        {
            FileStorage _storage = new FileStorage();
            var filepath = _configuration["Photo"] + file.Name;
            System.IO.Stream filecontent = await _storage.GetAsync(filepath);
            var filetype = _storage.GetContentType(filepath);
            return File(filecontent, filetype, file.Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Recruitment
{
    public class PersonRelativeModel : BasePage
    {
        public async Task<IActionResult> OnGetAsync([FromBody] decimal? PersonId)
        {
            try
            {

                
                List<SearchedPersonRelative> result = new List<SearchedPersonRelative>();
                result = await Mediator.Send(new SearchPersonRelativeQuery() { PersonId = PersonId });

                return new JsonResult(new Result()
                {
                    Data = new { list = result },
                    Status = Status.Success,
                    Text = string.Empty,
                    Description = string.Empty

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Result()
                {

                    Data = null,
                    Status = Status.Failure,
                    Text = CustomMessages.InternalSystemException,

                    Description = ex.Message
                });
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonRelativeQuery command)
        {

            try
            {

              



                List<SearchedPersonRelative> result = new List<SearchedPersonRelative>();
                result = await Mediator.Send(command);

                return new JsonResult(new Result()
                {
                    Data = new { list = result },
                    Status = Status.Success,
                    Text = string.Empty,
                    Description = string.Empty

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Result()
                {

                    Data = null,
                    Status = Status.Failure,
                    Text = CustomMessages.InternalSystemException,
                   
                    Description = ex.Message
                });
            }
        }
        public async Task<IActionResult> OnPostSave([FromBody]SavePersonRelatives command)
        {
            try
            {

                command.CreatedOn = DateTime.Now;
                command.ModifiedBy = "TEST";
                command.ModifiedBy = null;
                command.CreatedBy = 10;

                List<SearchedPersonRelative> result = new List<SearchedPersonRelative>();
                result = await Mediator.Send(command);

                return new JsonResult(new Result()
                {
                    Data = new { list = result },
                    Status = Status.Success,
                    Text = "شهرت اقارب کارمند موفقانه ثبت سیستم شد",
                    Description = string.Empty

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Result()
                {

                    Data = null,
                    Status = Status.Failure,
                    Text = CustomMessages.InternalSystemException,
                    // Can be changed from app settings
                    Description = ex.Message 
                });
            }
        }


        public async Task<IActionResult> OnPostDeleteRelative([FromBody]DeletePersonRelativesCommand deleteCommand)
        {
            Result result = new Result();

            try
            {
                string dbResult;
                dbResult = await Mediator.Send(deleteCommand);
                return new JsonResult(new Result()
                {
                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "شهرت اقارب کارمند موفقانه حذف شد",
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Result()
                {

                    Data = null,
                    Status = Status.Failure,
                    Text = CustomMessages.InternalSystemException,
                    // Can be changed from app settings
                    Description = ex.Message
                });

            }
        }
    }
}
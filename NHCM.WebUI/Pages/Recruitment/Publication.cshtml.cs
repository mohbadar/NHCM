using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Queries;
using NHCM.WebUI.Types;
using NHCM.Application.Recruitment.Models;

namespace NHCM.WebUI.Pages.Recruitment
{
    public class PublicationModel : BasePage
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSave([FromBody] SavePersonPublicationCommand command)
        {
            try
            {

                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;

                List<SearchedPersonPublication> result = new List<SearchedPersonPublication>();
                result = await Mediator.Send(command);

                return new JsonResult(new Result()
                {
                    Data = new { list = result },
                    Status = Status.Success,
                    Text = "انتشار کارمند موفقانه ثبت سیستم شد",
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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonPublicationQuery query)
        {
            try
            {
                List<SearchedPersonPublication> dbResult = new List<SearchedPersonPublication>();
                dbResult = await Mediator.Send(query);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
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
                    Description = ex.Message + " \n StackTrace : " + ex.StackTrace

                });
            }
        }
    }
}
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
    public class ReferenceModel : BasePage
    {
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostSave([FromBody]SavePersonReferenceCommand command)
        {
            try
            {
                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;

                List<SearchedPersonReference> dbResult = new List<SearchedPersonReference>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new NHCM.WebUI.Types.Result()
                {
                    Data = new { list = dbResult },
                    Status = NHCM.WebUI.Types.Status.Success,
                    Text = "  تضمین کارمند موفقانه ثبت سیستم شد",
                    Description = string.Empty

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.Result()
                {

                    Data = null,
                    Status = NHCM.WebUI.Types.Status.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message + " \n StackTrace : " + ex.StackTrace

                });
            }

        }

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonReferenceQuery query)
        {

            try
            {
                List<SearchedPersonReference> result = new List<SearchedPersonReference>();
                result = await Mediator.Send(query);

                return new JsonResult(new NHCM.WebUI.Types.Result()
                {
                    Data = new { list = result },
                    Status = NHCM.WebUI.Types.Status.Success,
                    Text = string.Empty,
                    Description = string.Empty

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.Result()
                {

                    Data = null,
                    Status = NHCM.WebUI.Types.Status.Failure,
                    Text = CustomMessages.InternalSystemException,

                    Description = ex.Message
                });
            }
        }

    }
}
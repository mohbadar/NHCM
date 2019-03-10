using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Lookup.Queries;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Recruitment
{
    public class HealthModel : BasePage
    {


       

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSave([FromBody]SavePersonHealthReportCommand command)
        {
            try
            {
                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;

                List<SearchedPersonHealthReport> dbResult = new List<SearchedPersonHealthReport>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new NHCM.WebUI.Types. Result()
                {
                    Data = new { list = dbResult },
                    Status = NHCM.WebUI.Types.Status.Success,
                    Text = "راپور صحی فرد موفقانه ثبت سیستم شد",
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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonHealthReportQuery command)
        {

            try
            {
                List<SearchedPersonHealthReport> result = new List<SearchedPersonHealthReport>();
                result = await Mediator.Send(command);

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
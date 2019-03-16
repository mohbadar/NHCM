using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Application.Organogram.Commands;
using NHCM.Application.Organogram.Models;
using NHCM.Application.Organogram.Queries;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Organogram
{
    public class PositionsModel : BasePage
    {
        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostSave([FromBody]SavePositionCommand command)
        {
            try
            {
                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;

                List<SearchedPosition> dbResult = new List<SearchedPosition>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new NHCM.WebUI.Types.Result()
                {
                    Data = new { list = dbResult },
                    Status = NHCM.WebUI.Types.Status.Success,
                    Text = "بست موفقانه ثبت سیستم شد",
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


        public async Task<IActionResult> OnPostSearch([FromBody] SearchPositionQuery command)
        {

            try
            {
                List<SearchedPosition> result = new List<SearchedPosition>();
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
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
    public class AssetModel : BasePage
    {
        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostSave([FromBody] SavePersonAssetCommand command)
        {
            try
            {

                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;

                List<SearchedPersonAsset> result = new List<SearchedPersonAsset>();
                result = await Mediator.Send(command);

                return new JsonResult(new Result()
                {
                    Data = new { list = result },
                    Status = Status.Success,
                    Text = "سرمایه کارمند موفقانه ثبت سیستم شد",
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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonAssetQuery query)
        {
            try
            {
                List<SearchedPersonAsset> dbResult = new List<SearchedPersonAsset>();
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


        public async Task<IActionResult> OnPostDelete([FromBody] DeletePersonAssetCommand command)
        {
            try
            {
                string dbResult = string.Empty;
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = " دارایی انتخاب شده موفقانه حذف  شد",
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
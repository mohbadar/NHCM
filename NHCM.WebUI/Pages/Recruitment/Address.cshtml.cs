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
    public class AddressModel : BasePage
    {
        public void OnGet()
        {

        }



        public async Task<IActionResult> OnPostSave([FromBody] SavePersonAddressCommand command)
        {
            try
            {
                command.CreatedBy = 10; // UNTILL : applicatio nof identity
                command.CreatedOn = DateTime.Now;
                command.ModifiedBy = "Test";
                command.ModifiedOn = DateTime.Now;
                List<SearchedPersonAdress> dbResult = new List<SearchedPersonAdress>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "آدرس فرد موفقانه ثبت سیستم گردید",
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

        public async Task<IActionResult> OnPostDelete([FromBody] DeletePersonAddressCommand command)
        {
            try
            {
                string dbResult = string.Empty;
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "اطلاعات تحصیلی انتخاب شده موفقانه حذف  شد",
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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonAddressQuery searchQuery)
        {
            try
            {
                List<SearchedPersonAdress> dbResult = new List<SearchedPersonAdress>();
                dbResult = await Mediator.Send(searchQuery);

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
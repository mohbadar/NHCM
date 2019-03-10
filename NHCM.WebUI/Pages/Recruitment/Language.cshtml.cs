using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using NHCM.WebUI.Types;
using NHCM.Application.Recruitment.Commands;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;

namespace NHCM.WebUI.Pages.Recruitment
{
    public class LanguageModel : BasePage
    {
       

       


        // Currently Taken the id from the route. Alternative would be be using FromBody. By providing data for the ajax request.
        public  void OnGet()
        {
            

        }


        public async Task<IActionResult> OnPostSave([FromBody] SavePersonLanguageCommand command)
        {
            try
            {
                List<SearchedPersonLanguage> dbResult = new List<SearchedPersonLanguage>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result() {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "اطلاعات زبان فرد موفقانه ثبت سیستم شد",
                    Description = string.Empty

                });


            }
            catch(Exception ex)
            {
                return new JsonResult(new Result()
                {

                    Data = null,
                    Status = Status.Failure,
                    Text = CustomMessages.InternalSystemException ,
                    Description = ex.Message + " \n StackTrace : "+ ex.StackTrace

                });
            }
        }




        public async Task<IActionResult> OnPostDelete([FromBody] DeletePersonLanguageCommand command)
        {
            try
            {
                string dbResult= string.Empty;
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "زبان انتخاب شده موفقانه حذف گردید",
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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchPersonLanguageQuery command)
        {
            try
            {
                List<SearchedPersonLanguage> dbResult = new List<SearchedPersonLanguage>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text =string.Empty,
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
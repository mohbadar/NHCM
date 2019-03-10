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
    public class PersonSkillModel : BasePage
    {
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostSave([FromBody] SavePersonSkillsCommand command)
        {
            try
            {
                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;
               
                List<SearchedPersonSkill> dbResult = new List<SearchedPersonSkill>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new Result()
                {

                    Data = new { list = dbResult },
                    Status = Status.Success,
                    Text = "مهارت فرد موفقانه ثبت سیستم شد",
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



        public async Task<IActionResult> OnPostSearch([FromBody]SearchPersonSkillQuery command)
        {
            try
            {
                

                List<SearchedPersonSkill> dbResult = new List<SearchedPersonSkill>();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Application.Employment.Models;
using NHCM.Application.Reports.Queries;
using NHCM.Domain.ViewsEntities;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Reports
{
    public class AttendanceDailyReportModel : BasePage
    {
        //[BindProperty(SupportsGet = true)]
        //public string startdate { get; set; } = "test";


        //[BindProperty]
        //public DateTime enddate { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSearch([FromBody] SearchAttendanceReportQuery searchQuery)
        {
           
            try
            {
                List<AttendanceReport> dbResult = new List<AttendanceReport>();
               
                dbResult = await Mediator.Send(searchQuery);

                return new JsonResult(new UIResult()
                {

                    Data = new { list = dbResult },
                    Status = UIStatus.Success,
                    Text = string.Empty,
                    Description = string.Empty

                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new UIResult()
                {

                    Data = null,
                    Status = UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message + " \n StackTrace : " + ex.StackTrace
                });
            }
        }

    }
}
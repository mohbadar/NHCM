using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Employment.Commands;
using NHCM.Application.Employment.Models;
using NHCM.Application.Employment.Queries;
using NHCM.Application.Lookup.Queries;
using NHCM.Application.Organogram.Models;
using NHCM.Application.Organogram.Queries;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Employment
{
    public class SelectionModel : BasePage
    {

        public async Task OnGetAsync()
        {

            //ListOfEventType = new List<SelectListItem>();
            //
            //
            //foreach (EventType e in EventTypes)
            //    ListOfEventType.Add(new SelectListItem(e.Name, e.Id.ToString()));

        }

        public async Task<IActionResult> OnPostEvents(string body)
        {
            try
            {
                List<EventType> EventTypes = new List<EventType>();
                EventTypes = await Mediator.Send(new GetEventTypeQuery() { ID = null });

                List<object> result = new List<object>();
                foreach (EventType e in EventTypes)
                    result.Add(new { Text = e.Name, ID = e.Id.ToString() });
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = result },
                    Status = NHCM.WebUI.Types.UIStatus.Success,
                    Text = string.Empty,
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message
                });
            }
        }


        public async Task<IActionResult> OnPostEmployees(string body)
        {
            try
            {
                List<SearchedPersonModel> Persons = new List<SearchedPersonModel>();
                Persons = await Mediator.Send(new SearchPersonQuery() { Id = null });
                List<object> result = new List<object>();
                foreach (SearchedPersonModel p in Persons)
                    result.Add(new { Text = p.FirstName + "  " + p.LastName, ID = p.Id.ToString() });
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = result },
                    Status = NHCM.WebUI.Types.UIStatus.Success,
                    Text = string.Empty,
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message
                });
            }
        }


        public async Task<IActionResult> OnPostSave([FromBody]CreateSelectionCommand command)
        {
            try
            {
                List<SearchedPosition> dbResult = new List<SearchedPosition>();
                dbResult = await Mediator.Send(command);
                return new JsonResult(new Types.UIResult()
                {
                    Data = new { list = dbResult },
                    Status = Types.UIStatus.Success,
                    Text = "پیشنهاد تعیینات موفقانه ثبت سیستم گردید",
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Types.UIResult()
                {
                    Data = null,
                    Status = Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message + " \n StackTrace : " + ex.StackTrace
                });
            }
        }

        public async Task<IActionResult> OnPostSearch([FromBody] SearchSelectionQuery command)
        {
            try
            {
                List<SearchedSelectionModel> result = new List<SearchedSelectionModel>();
                result = await Mediator.Send(command);
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = result },
                    Status = NHCM.WebUI.Types.UIStatus.Success,
                    Text = string.Empty,
                    Description = string.Empty
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {

                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,

                    Description = ex.Message
                });
            }
        }
    }
}
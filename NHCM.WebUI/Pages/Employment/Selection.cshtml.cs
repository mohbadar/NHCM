using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Employment.Commands;
using NHCM.Application.Employment.Models;
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
            ListOfPerson = new List<SelectListItem>();
            List<SearchedPersonModel> Persons = new List<SearchedPersonModel>();
            Persons = await Mediator.Send(new SearchPersonQuery() { Id = null });
            foreach (SearchedPersonModel p in Persons)
                ListOfPerson.Add(new SelectListItem(p.FirstName + " " + p.LastName, p.Id.ToString()));

            ListOfPosition = new List<SelectListItem>();
            List<SearchedPosition> Positions = new List<SearchedPosition>();
            Positions = await Mediator.Send(new SearchPositionQuery() { });
            foreach (SearchedPosition p in Positions)
                ListOfPosition.Add(new SelectListItem(p.Id.ToString(), p.Id.ToString()));

            ListOfEventType = new List<SelectListItem>();
            List<EventType> EventTypes = new List<EventType>();
            EventTypes = await Mediator.Send(new GetEventTypeQuery() { ID = null });
            foreach (EventType e in EventTypes)
                ListOfEventType.Add(new SelectListItem(e.Name, e.Id.ToString()));

        }

        public async Task<IActionResult> OnPostSave([FromBody]CreateSelectionCommand command)
        {

            try
            {
                List<SearchedSelectionModel> dbResult = new List<SearchedSelectionModel>();
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
    }
}
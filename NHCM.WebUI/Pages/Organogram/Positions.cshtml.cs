using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Lookup.Queries;
using NHCM.Application.Organogram.Commands;
using NHCM.Application.Organogram.Models;
using NHCM.Application.Organogram.Queries;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Organogram
{
   
    public class PositionsModel : BasePage
    {
        
        public async Task OnGetAsync()
        {
            // Page Specific Lookups
            ListOfPlanType = new List<SelectListItem>();
            List<PlanType> plantype = new List<PlanType>();
            plantype = await Mediator.Send(new GetPlanTypeQuery() { Id = null });
            foreach (PlanType planT in plantype)
                ListOfPlanType.Add(new SelectListItem() { Text = planT.Name, Value = planT.Id.ToString() });


            /// change organogramid to dynamic id 
            ListOfReportTo = new List<SelectListItem>();
            List<Position> reportTo = new List<Position>();
            reportTo = await Mediator.Send(new GetReportToQuery() { organogramid = 3 });
            foreach (Position reportto in reportTo)
                ListOfReportTo.Add(new SelectListItem() { Text = reportto.Name, Value = reportto.Id.ToString() });


           ListOfPositionType = new List<SelectListItem>();
            List<PositionType> Positiontype = new List<PositionType>();
            Positiontype = await Mediator.Send(new GetPositionTypeQuery() { Id = null });
            foreach (PositionType planT in Positiontype)
                ListOfPositionType.Add(new SelectListItem() { Text = planT.Name, Value = planT.Id.ToString() });



            ListOfRanks = new List<SelectListItem>();
            List<Rank> ranks = new List<Rank>();
            ranks = await Mediator.Send(new GetRankQuery() { ID = null });
            foreach (Rank rank in ranks)
                ListOfRanks.Add(new SelectListItem() { Text = rank.Name, Value = rank.Id.ToString() });


            ListOfSalaryType = new List<SelectListItem>();
            List<SalaryType> salaryTypes = new List<SalaryType>();
            salaryTypes = await Mediator.Send(new GetSalaryTypeQuery() { Id = null });
            foreach (SalaryType salary in salaryTypes)
                ListOfSalaryType.Add(new SelectListItem() { Text = salary.Dari, Value = salary.Id.ToString() });


            //Get Locations
            ListOfLocations = new List<SelectListItem>();
            List<Location> locations = new List<Location>();
            locations = await Mediator.Send(new GetLocationQuery() { ID = null });
            foreach (Location l in locations)
                ListOfLocations.Add(new SelectListItem(l.Dari, l.Id.ToString()));

            ListOfEducationLevels = new List<SelectListItem>();
            List<EducationLevel> educationLevels = new List<EducationLevel>();
            educationLevels = await Mediator.Send(new GetEducationLevelQuery() { ID = null });
            foreach (EducationLevel level in educationLevels)
                ListOfEducationLevels.Add(new SelectListItem() { Text = level.Name, Value = level.Id.ToString() });

        }


        public async Task<IActionResult> OnPostSave([FromBody]SavePositionCommand command)
        {
            try
            {
                command.CreatedBy = 10;
                command.ModifiedBy = "Test";
                command.CreatedOn = DateTime.Now;
                command.ModifiedOn = DateTime.Now;
                command.StatusId = 51;

                List<SearchedPosition> dbResult = new List<SearchedPosition>();
                dbResult = await Mediator.Send(command);

                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = dbResult },
                    Status = NHCM.WebUI.Types.UIStatus.Success,
                    Text = "بست موفقانه ثبت سیستم شد",
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
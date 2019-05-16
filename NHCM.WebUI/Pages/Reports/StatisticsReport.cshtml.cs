using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Lookup.Queries;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.Reports
{
    public class StatisticsReportModel : BasePage
    {
        public async Task OnGetAsync()
        {
            //Get Organization
            ListOfOrganization = new List<SelectListItem>();
            List<Organization> organizations = new List<Organization>();
            organizations = await Mediator.Send(new GetOrganiztionQuery() { Id = null });
            foreach (Organization organization in organizations)
                ListOfOrganization.Add(new SelectListItem(organization.Dari, organization.Id.ToString()));
        }
    }
}
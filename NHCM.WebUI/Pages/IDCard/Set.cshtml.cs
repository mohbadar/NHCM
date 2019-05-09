using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.Persistence.Infrastructure.Identity;
using NHCM.WebUI.Types;

namespace NHCM.WebUI.Pages.IDCard
{
    public class SetModel : BasePage
    {

        private readonly UserManager<HCMUser> _userManager;
        public int? SignedInUserOrganizationID { get; set; }

        public SetModel(UserManager<HCMUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnGet()
        {
            // Get List Of  Persons
            ListOfPerson = new List<SelectListItem>();
            List<SearchedPersonModel> searchedPeople = new List<SearchedPersonModel>();
            // CHANGE: change the SearchPersonQuery Request to include a property to bring all records not only 10000
            searchedPeople = await Mediator.Send(new SearchPersonQuery() { OrganizationId = SignedInUserOrganizationID, NoOfRecords = 10000 });

            foreach (SearchedPersonModel person in searchedPeople)
            {
                ListOfPerson.Add(new SelectListItem()
                {
                    Text = new StringBuilder() { }.Append(person.FirstName).Append(" فرزند ").Append(" ").Append(person.FatherName).ToString(),
                    Value = person.Id.ToString()
                });
            }
        }
    }
}
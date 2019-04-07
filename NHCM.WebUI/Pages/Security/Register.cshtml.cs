using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Lookup.Queries;
using NHCM.Application.Recruitment.Models;
using NHCM.Application.Recruitment.Queries;
using NHCM.Domain.Entities;
using NHCM.Persistence.Infrastructure.Identity;
using NHCM.Persistence.Infrastructure.Services;
using NHCM.WebUI.Types;
namespace NHCM.WebUI.Areas.Security.Pages
{
    [Authorize("UserRegistrar")]
    public class RegisterModel : BasePage
    {


      
        public int? SignedInUserOrganizationID { get; set; }
       

        
       

        private readonly SignInManager<HCMUser> _signInManager;
        private readonly UserManager<HCMUser> _userManager;
        private readonly ICurrentUser _currentUser;

        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }



        [BindProperty]
        [Display(Name = "لست افراد ارگان")]
        [Required(ErrorMessage = "انتخاب کارمند ضروری میباش")]
        public int EmployeeID { get; set; }


        [BindProperty]
        [Display(Name = "ارگان")]
        [Required(ErrorMessage = "انتخاب موسسه ضروری میباشد")]
        public int OrganizationID { get; set; }



        [BindProperty]
        [DataType(DataType.EmailAddress, ErrorMessage = "لطفا ایمل درست را وارد کنید")]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل فرد ضروری میباشد")]
        public string Email { get; set; }


        [BindProperty]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "نام کاربری ضروری میباشد")]
        public string UserName { get; set; }


        [BindProperty]
        [StringLength(100, ErrorMessage = "رمز عبور باید حد اقل دارای 6 حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز عبور ضروری میباشد")]
        public string Password { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تاییدی آن مطابقت ندارد")]
        [Required(ErrorMessage = "تایید رمز عبور ضروری میباشد")]
        public string ConfirmPassword { get; set; }


        public RegisterModel(
           UserManager<HCMUser> userManager,
           SignInManager<HCMUser> signInManager, ICurrentUser currentUser)
           
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _currentUser = currentUser;
           
        }
        public async Task OnGetAsync(string url = null)
        {
            ReturnUrl = url;

            HCMUser signedInUser = await _userManager.GetUserAsync(User);
            SignedInUserOrganizationID = signedInUser.OrganizationID;


            //Get Organization
            ListOfOrganization = new List<SelectListItem>();
            List<Organization> organizations = new List<Organization>();
            organizations = await Mediator.Send(new GetOrganiztionQuery() { Id = SignedInUserOrganizationID ?? default(int) });
            foreach (Organization organization in organizations)
                ListOfOrganization.Add(new SelectListItem(organization.Dari, organization.Id.ToString()));


            // Get List Of  Persons
            ListOfPerson = new List<SelectListItem>();
            List<SearchedPersonModel> searchedPeople = new List<SearchedPersonModel>();
            // CHANGE: change the SearchPersonQuery Request to include a property to bring all records not only 10000
            searchedPeople = await Mediator.Send(new SearchPersonQuery() { OrganizationId = await _currentUser.GetUserOrganizationID(), NoOfRecords = 10000 });

            foreach (SearchedPersonModel person in searchedPeople)
            {
                ListOfPerson.Add(new SelectListItem()
                {
                    Text = new StringBuilder() { }.Append( person.FirstName ). Append(" فرزند ").Append(" ").Append(person.FatherName).ToString(),
                    Value = person.Id.ToString()
                });
            }
                
          
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                HCMUser user = new HCMUser { UserName = UserName, Email = Email, OrganizationID = Convert.ToInt32(OrganizationID), EmployeeID = EmployeeID };
                IdentityResult result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect(returnUrl);
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    ErrorMessage +="\n " +error.Description;
                }
            }

            return Page();

        }




        //public async Task OnPostSearch()
        //{


            
        //    ListOfPersons = new List<SearchedPersonModel>();
        //    ListOfPersons = await Mediator.Send(new SearchPersonQuery() {  OrganizationId = OrganizationID });

        //  //  return Page();
           
        //}

    }

        
}
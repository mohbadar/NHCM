using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Persistence.Infrastructure.Identity;
using NHCM.WebUI.Types;
namespace NHCM.WebUI.Areas.Security.Pages
{
    [AllowAnonymous]
    public class RegisterModel : BasePage
    {


        public string ErrorMessage { get; set; }

        private readonly SignInManager<HCMUser> _signInManager;
        private readonly UserManager<HCMUser> _userManager;

        public string ReturnUrl { get; set; }


        [BindProperty]
        [Required]
        public string OrganizationID { get; set; }


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
           SignInManager<HCMUser> signInManager)
           
        {
            _userManager = userManager;
            _signInManager = signInManager;
           
        }
        public void OnGetAsync(string url = null)
        {
            ReturnUrl = url;
        }



        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                HCMUser user = new HCMUser { UserName = UserName, Email = Email, OrganizationID = Convert.ToInt32(OrganizationID) };
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
    }
}
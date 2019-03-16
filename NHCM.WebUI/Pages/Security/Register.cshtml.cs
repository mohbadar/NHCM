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

namespace NHCM.WebUI.Areas.Security.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {


        public string ErrorMessage { get; set; }

        private readonly SignInManager<HCMUser> _signInManager;
        private readonly UserManager<HCMUser> _userManager;

        public string ReturnUrl { get; set; }

        [BindProperty]
        [Required]
        public string UserName { get; set; }

        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [BindProperty]
        [Required]
        public string Password { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تاییدی آن مطابقت ندارد")]
       
        [Required]
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
                HCMUser user = new HCMUser { UserName = UserName };
                IdentityResult result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect(returnUrl);
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    ErrorMessage += error.Description;
                }
            }

            return Page();

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Persistence.Identity.Infrastructure;
using NHCM.Persistence.Infrastructure.Identity;

namespace NHCM.WebUI.Pages.Security
{



    [AllowAnonymous]
    public class LoginModel : PageModel
    {


        private readonly SignInManager<HCMUser> _signInManger;
       // private readonly UserInitializer _userInitializer;
        
        public LoginModel(SignInManager<HCMUser> signInManager)
        {
            _signInManger = signInManager;
           
        }


        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public async void OnGetAsync(string returnUrl = null)
        {


            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

         //   ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManger.PasswordSignInAsync(UserName, Password, false, false);

                if (result.Succeeded)
                {
                    return LocalRedirect("/index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "کوشش نا موفق لطفا دوباره کوشش کنید");
                    return Page();
                }
            }
            return Page();
        }
    }
}
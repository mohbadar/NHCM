using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Persistence.Infrastructure.Identity;

namespace NHCM.WebUI.Pages.Security
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<HCMUser> _signInManager;

        public LogoutModel(SignInManager<HCMUser> signInManager)
        {
            _signInManager = signInManager;
        }

        
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            if(returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
           
        }
    }
}
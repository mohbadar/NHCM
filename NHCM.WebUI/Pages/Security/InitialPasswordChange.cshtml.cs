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

namespace NHCM.WebUI.Pages.Security
{

    [Authorize(Policy = "FreshUserPolicy")]
    public class InitialPasswordChangeModel : PageModel
    {
        #region VM
        [BindProperty]
        [Display(Name = "رمز عبور")]
        [Required]
        public string CurrentPassword { get; set; }

        [BindProperty]
        [Display(Name = "رمز عبور جدید")]
        [Required]
        public string NewPassword { get; set; }

        [BindProperty]
        [Display(Name = "تکرار رمز عبور جدید")]
        [Compare("NewPassword", ErrorMessage = "رمز جدید و تاییدی آن مطابقت ندارد")]
        [Required]
        public string NewPasswordConfirmation { get; set; }
        #endregion VM

        #region DI
        private readonly UserManager<HCMUser> _userManager;
        private readonly SignInManager<HCMUser> _signInManager;
        public InitialPasswordChangeModel(UserManager<HCMUser> usermanager, SignInManager<HCMUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }
        #endregion DI


        public async Task OnPostChangePassword()
        {

            await _userManager.FindByNameAsync(User.Identity.Name);
            
   
        }
        public void OnGet()
        {

        }
    }
}
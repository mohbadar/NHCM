using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NHCM.WebUI.Pages.Lookups
{
    [Authorize(Policy = "SuperAdminPolicy")]
    public class OrganizationModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
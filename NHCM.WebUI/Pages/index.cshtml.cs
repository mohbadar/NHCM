using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;
using MediatR;
using NHCM.Application.Lookup.Queries;
using System.Threading.Tasks;

namespace NHCM.WebUI.Pages
{
    public class indexModel : BasePage
    {

        public string rowtemplate = @"<div class='row'>$cols</div><hr/>";

        public string htmltemplate = @"
                                    <div class='col-md-3 pull-right'>
                                        <a href='$link?p=$id'>
                                            <img src='assets/icons/$icon' />
                                            <h5>$title</h5>
                                            <span>$des</span>
                                        </a>
                                    </div>
                                    ";

        public string HTML { get; set; } = "";

        List<Screens> slist = new List<Screens>();


        public async Task OnGetAsync([FromBody] GetScreens command)
        {
            command = new GetScreens();
            try
            {
                slist = await Mediator.Send(command);
                Loadscreens(slist);
            }
            catch (Exception ex)
            {

            }
        }

        private void Loadscreens(List<Screens> list)
        {
            int rownumber = (list.Count % 4) == 0 ? list.Count / 4 : (list.Count / 4) + 1;

            string row = "";

            List<Screens> l = list;

            for (int i = 1; i <= rownumber; i++)
            {
                string cols = "";
                for (int j = 0; j <= 3; j++)
                {
                    if (list.Count > 0)
                    {
                        Screens s = l[0];
                        String screenid = RijndaelManagedEncryption.RijndaelManagedEncryption.EncryptRijndael(s.Id.ToString(), "P@33word");
                        cols = cols + htmltemplate.Replace("$id", screenid).Replace("$title", s.Title).Replace("$icon", s.Icon).Replace("$des", s.Description).Replace("$link", s.Path);
                        l.RemoveAt(0);
                    }
                    // cols = cols + htmltemplate;
                }
                row = row + rowtemplate.Replace("$cols", cols);
            }
            HTML = HTML + row;
        }


    }
}
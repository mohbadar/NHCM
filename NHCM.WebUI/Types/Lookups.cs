using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHCM.Application.Lookup.Queries;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHCM.WebUI.Types
{
    public  class Lookups
    {
        // private  IMediator _mediator;

        private  Mediator mediator;
        public Lookups(/*IMediator mediator*/)
        {
            //_mediator = mediator;
            InitListOfGenders();
        }

        public static List<SelectListItem> ListOfGenders = new List<SelectListItem>();
     
       
        public   async  void InitListOfGenders()
        {
            List<Gender> Genders = new List<Gender>();
            Genders = await mediator.Send(new GetGenderQuery() { ID = null });
            foreach (Gender gender in Genders)
                ListOfGenders.Add(new SelectListItem(gender.Dari, gender.ID.ToString()));

            
         
        }
    }
}

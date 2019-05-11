using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Employment.Models
{
   public class SearchedIdentityCardModel
    {
        public long Id { get; set; }
        public string CardCode { get; set; }
        public decimal PersonId { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string PhotoPath { get; set; }
         public bool? CardPrinted { get; set; }

    }
}

using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Lookup.Models
{
    public class SearchedProcess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Predecessor { get; set; }
        public int Successor { get; set; }
        public int ModuleId { get; set; }
        public int ScreenId { get; set; }
        public int OnSuccessStatus { get; set; }
        public int OnFailureStatus { get; set; }

    }
}

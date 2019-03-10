using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Ethnicity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? CountryId { get; set; }
    }
}

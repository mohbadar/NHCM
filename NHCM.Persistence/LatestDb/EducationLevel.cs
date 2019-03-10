using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class EducationLevel
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short? Parentid { get; set; }
        public string Sorter { get; set; }
    }
}

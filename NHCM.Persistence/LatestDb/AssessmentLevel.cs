using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class AssessmentLevel
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }
    }
}

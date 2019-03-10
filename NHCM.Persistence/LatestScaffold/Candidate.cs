using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class Candidate
    {
        public decimal PersonId { get; set; }
        public char? Request { get; set; }
        public char? ShortList { get; set; }
        public char? Eligibility { get; set; }
        public char? Education { get; set; }
        public char? Health { get; set; }
        public char? SecurityCheck { get; set; }
        public char? Agreement { get; set; }
        public char? Orientation { get; set; }
        public char? Ready { get; set; }
        public char? Hired { get; set; }
    }
}

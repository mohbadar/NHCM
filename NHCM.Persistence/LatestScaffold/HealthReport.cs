using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class HealthReport
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public DateTime ReportDate { get; set; }
        public int StatusId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public bool? Approved { get; set; }
        public string Remarks { get; set; }
    }
}

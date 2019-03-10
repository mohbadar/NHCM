using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Retirement
    {
        public decimal Id { get; set; }
        public decimal EventId { get; set; }
        public decimal PersonId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Remarks { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ReasonId { get; set; }
    }
}

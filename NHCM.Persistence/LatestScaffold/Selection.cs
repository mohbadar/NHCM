using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class Selection
    {
        public decimal PositionId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Id { get; set; }
        public int EventTypeId { get; set; }
        public decimal PersonId { get; set; }
        public short? CategoryId { get; set; }
        public decimal? EventId { get; set; }
        public string Remarks { get; set; }
        public string OldPosition { get; set; }
        public decimal? OrganizationId { get; set; }
        public DateTime? VerdictDate { get; set; }
        public string VerdictRegNo { get; set; }
        public string FinalNo { get; set; }
        public short? RankId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}

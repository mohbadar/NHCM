using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Promotion
    {
        public int EventTypeId { get; set; }
        public decimal PersonId { get; set; }
        public short RankId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public decimal Id { get; set; }
        public decimal? EventId { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public short? Year { get; set; }
        public short? Month { get; set; }
        public short? Day { get; set; }
        public decimal? SupervisorId { get; set; }
        public string Characteristic { get; set; }
        public short? CharacteristicResultId { get; set; }
        public string PresidentialOrderNo { get; set; }
        public DateTime? PresidentialOrderDate { get; set; }
        public string Remarks { get; set; }
    }
}

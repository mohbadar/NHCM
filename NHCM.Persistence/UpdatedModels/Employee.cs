using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Employee
    {
        public decimal PersonId { get; set; }
        public short EmploymentStatusId { get; set; }
        public short CategoryId { get; set; }
        public decimal? OrgUnitId { get; set; }
        public decimal? PositionId { get; set; }
        public short? RankId { get; set; }
        public int? LocationId { get; set; }
        public short? Year { get; set; }
        public short? Month { get; set; }
        public short? Day { get; set; }
        public DateTime? FirstHireDate { get; set; }
        public short? TotalYear { get; set; }
        public short? TotalMonth { get; set; }
        public short? TotalDay { get; set; }
        public DateTime? LastPromotionDate { get; set; }
        public string ReferenceNo { get; set; }

        public virtual OrgUnit OrgUnit { get; set; }
        public virtual Position Position { get; set; }
    }
}

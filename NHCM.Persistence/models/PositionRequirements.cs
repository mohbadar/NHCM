using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class PositionRequirements
    {
        public decimal Id { get; set; }
        public decimal PositionId { get; set; }
        public short EducationLevelId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ExperianceNoOfYear { get; set; }
        public string Remarks { get; set; }
    }
}

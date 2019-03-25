using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class RankSalary
    {
        public short Id { get; set; }
        public short RankId { get; set; }
        public decimal Salary { get; set; }
        public DateTime EffectDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Modifiedby { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}

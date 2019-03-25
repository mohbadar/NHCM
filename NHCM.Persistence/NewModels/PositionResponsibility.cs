using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class PositionResponsibility
    {
        public decimal PositionId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Modifiedby { get; set; }
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public decimal? ParentId { get; set; }
        public string Purpose { get; set; }
        public string Characteristic { get; set; }

        public virtual Position Position { get; set; }
    }
}

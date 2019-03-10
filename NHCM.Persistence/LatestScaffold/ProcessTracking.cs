using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class ProcessTracking
    {
        public int Id { get; set; }
        public int? RecordId { get; set; }
        public short? ProcessId { get; set; }
        public short? ReferedProcessId { get; set; }
        public short? StatusId { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

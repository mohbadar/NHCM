using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Attendance
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public bool Presence { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int LeavetypeId { get; set; }
        public decimal? Workinghours { get; set; }
        public int? StatusId { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public DateTime? Date { get; set; }

        public virtual Attendance IdNavigation { get; set; }
        public virtual Person Person { get; set; }
        public virtual Attendance InverseIdNavigation { get; set; }
    }
}

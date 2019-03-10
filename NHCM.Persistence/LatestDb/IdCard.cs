using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class IdCard
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? NoOfIssue { get; set; }
        public string CardClassType { get; set; }
        public int? StatusId { get; set; }

        public virtual Person Person { get; set; }
    }
}

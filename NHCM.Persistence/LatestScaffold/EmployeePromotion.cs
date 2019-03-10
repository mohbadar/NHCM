using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class EmployeePromotion
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public string AuthorizeNumber { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public string RequestNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Promotion { get; set; }
        public string Remarks { get; set; }
        public DateTime? PromotionDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Person Person { get; set; }
    }
}

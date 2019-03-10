using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class JudgesPromotion
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public int RankId { get; set; }
        public string MaktobNumber { get; set; }
        public DateTime? MaktobDate { get; set; }
        public string EnteryNumber { get; set; }
        public DateTime? EnteryDate { get; set; }
        public string AuthorizeNo { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public string ImplementionNo { get; set; }
        public DateTime? ImplementionDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual JudgesPromotion IdNavigation { get; set; }
        public virtual Person Person { get; set; }
        public virtual JudgesPromotion InverseIdNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class PersonIdentification
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public short? TypeId { get; set; }
        public string Idno { get; set; }
        public DateTime? IssuedOn { get; set; }
        public DateTime? Expiration { get; set; }
        public string PassportIdno { get; set; }
        public DateTime? PassportIssuedOn { get; set; }
        public DateTime? PassportExpiresOn { get; set; }
        public string BookNumber { get; set; }
        public string PageNumber { get; set; }
        public string RegisterNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? TazkraIssueDate { get; set; }
        public int? TazkraLocation { get; set; }
        public string Remarks { get; set; }
    }
}

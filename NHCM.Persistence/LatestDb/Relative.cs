using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Relative
    {
        public string FatherName { get; set; }
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? PersonId { get; set; }
        public string GrandFatherName { get; set; }
        public short? RelationShipId { get; set; }
        public string NidNo { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string PersonalProperty { get; set; }
        public string EmailAddress { get; set; }
        public string CurrentVillage { get; set; }
        public string Village { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? LocationId { get; set; }
        public short? ReligionId { get; set; }
        public string JobLocation { get; set; }
        public string Remark { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}

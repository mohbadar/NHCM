using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Person
    {
        public Person()
        {
            Attendance = new HashSet<Attendance>();
            EmployeePromotion = new HashSet<EmployeePromotion>();
            IdCard = new HashSet<IdCard>();
            JudgesPromotion = new HashSet<JudgesPromotion>();
            MilitaryService = new HashSet<MilitaryService>();
            PersonAsset = new HashSet<PersonAsset>();
            PersonDocument = new HashSet<PersonDocument>();
            PersonLanguage = new HashSet<PersonLanguage>();
            PersonSkill = new HashSet<PersonSkill>();
            Publication = new HashSet<Publication>();
            Travel = new HashSet<Travel>();
        }

        public string FatherName { get; set; }
        public decimal Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string FirstName { get; set; }
        public string Hrcode { get; set; }
        public string LastName { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string HashKey { get; set; }
        public string PreFix { get; set; }
        public int? Suffix { get; set; }
        public string GrandFatherName { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string FatherNameEng { get; set; }
        public string GrandFatherNameEng { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BirthLocationId { get; set; }
        public int? GenderId { get; set; }
        public short? MaritalStatusId { get; set; }
        public int? EthnicityId { get; set; }
        public short? ReligionId { get; set; }
        public string Comments { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? BloodGroupId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string PhotoPath { get; set; }
        public string Nid { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<EmployeePromotion> EmployeePromotion { get; set; }
        public virtual ICollection<IdCard> IdCard { get; set; }
        public virtual ICollection<JudgesPromotion> JudgesPromotion { get; set; }
        public virtual ICollection<MilitaryService> MilitaryService { get; set; }
        public virtual ICollection<PersonAsset> PersonAsset { get; set; }
        public virtual ICollection<PersonDocument> PersonDocument { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
        public virtual ICollection<PersonSkill> PersonSkill { get; set; }
        public virtual ICollection<Publication> Publication { get; set; }
        public virtual ICollection<Travel> Travel { get; set; }
    }
}

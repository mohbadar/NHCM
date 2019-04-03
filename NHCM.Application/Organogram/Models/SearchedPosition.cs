
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Organogram.Models
{
    public class SearchedPosition
    {

        public decimal Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public decimal? ParentId { get; set; }
        public decimal? OrgunitId { get; set; }
        public short? PositionTypeId { get; set; }
        public short? RankId { get; set; }
        public int? StatusId { get; set; }
        public string Code { get; set; }
        public int? LocationId { get; set; }
        public int? DirectorateId { get; set; }
        public string Profession { get; set; }
        public string Kadr { get; set; }
        public string Remarks { get; set; }
        public int? SalaryTypeId { get; set; }
        public string Sorter { get; set; }
        public int? OrganoGramId { get; set; }
        public decimal? TransferPositionId { get; set; }
        public short? PlanTypeId { get; set; }
        public int? EducationLevelId { get; set; }
        public short? ExperienceNoOfYear { get; set; }
        public string PositionResponsibilityAndPurpose { get; set; }

        public string PositionTypeText { get; set; }
        public string LocationText { get; set; }
        public string RankText { get; set; }
        public string ParentText { get; set; }
        public string StatusText { get; set; }
        public string SalaryTypeText { get; set; }
        public string PlanTypeText { get; set; }
        //public int? Year { get; set; }

    }
}

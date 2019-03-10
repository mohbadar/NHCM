using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class Position
    {
        public Position()
        {
            InverseParent = new HashSet<Position>();
        }

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

        public virtual Position Parent { get; set; }
        public virtual ICollection<Position> InverseParent { get; set; }
    }
}

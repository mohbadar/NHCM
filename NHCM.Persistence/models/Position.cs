using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class Position
    {
        public Position()
        {
            InverseParent = new HashSet<Position>();
            Selection = new HashSet<Selection>();
        }

        public decimal Id { get; set; }
        public string Reference { get; set; }
        public decimal? ParentId { get; set; }
        public short? PositionTypeId { get; set; }
        public int? StatusId { get; set; }
        public string Code { get; set; }
        public int? LocationId { get; set; }
        public int? SalaryTypeId { get; set; }
        public string Sorter { get; set; }
        public int? OrganoGramId { get; set; }
        public short? PlanTypeId { get; set; }
        public int? WorkingAreaId { get; set; }

        public virtual Position Parent { get; set; }
        public virtual ICollection<Position> InverseParent { get; set; }
        public virtual ICollection<Selection> Selection { get; set; }
    }
}

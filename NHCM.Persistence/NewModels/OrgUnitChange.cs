using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class OrgUnitChange
    {
        public decimal Id { get; set; }
        public int OrganogramId { get; set; }
        public decimal OrgUnitId { get; set; }
        public short PlanTypeId { get; set; }
        public bool? IsAddition { get; set; }
        public string Name { get; set; }
        public decimal? NeworgUnitId { get; set; }

        public virtual OrgUnit NeworgUnit { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }
        public virtual OrganoGram Organogram { get; set; }
    }
}

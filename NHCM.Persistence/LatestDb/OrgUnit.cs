using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class OrgUnit
    {
        public OrgUnit()
        {
            InverseParent = new HashSet<OrgUnit>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Modifiedby { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public decimal? ParentId { get; set; }
        public int? LocationId { get; set; }
        public string Code { get; set; }
        public int? StatusId { get; set; }
        public short? OrgunitTypeId { get; set; }
        public string Sorter { get; set; }
        public int? OrganOgramId { get; set; }

        public virtual OrganoGram OrganOgram { get; set; }
        public virtual OrgUnit Parent { get; set; }
        public virtual ICollection<OrgUnit> InverseParent { get; set; }
    }
}

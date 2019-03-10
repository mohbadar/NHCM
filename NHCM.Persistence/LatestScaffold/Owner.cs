using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class Owner
    {
        public Owner()
        {
            InverseParent = new HashSet<Owner>();
        }

        public int OrgUnitId { get; set; }
        public short StatusId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int? ParentId { get; set; }
        public string ReferenceNo { get; set; }

        public virtual Owner Parent { get; set; }
        public virtual ICollection<Owner> InverseParent { get; set; }
    }
}

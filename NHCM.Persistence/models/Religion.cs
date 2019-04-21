using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class Religion
    {
        public Religion()
        {
            InverseParent = new HashSet<Religion>();
            Relative = new HashSet<Relative>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }

        public virtual Religion Parent { get; set; }
        public virtual ICollection<Religion> InverseParent { get; set; }
        public virtual ICollection<Relative> Relative { get; set; }
    }
}

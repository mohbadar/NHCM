using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class TrainingType
    {
        public TrainingType()
        {
            InverseParent = new HashSet<TrainingType>();
            Major = new HashSet<Major>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }
        public string Category { get; set; }

        public virtual TrainingType Parent { get; set; }
        public virtual ICollection<TrainingType> InverseParent { get; set; }
        public virtual ICollection<Major> Major { get; set; }
    }
}

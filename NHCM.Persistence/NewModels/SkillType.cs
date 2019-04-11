using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class SkillType
    {
        public SkillType()
        {
            Certification = new HashSet<Certification>();
            InverseParent = new HashSet<SkillType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual SkillType Parent { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<SkillType> InverseParent { get; set; }
    }
}

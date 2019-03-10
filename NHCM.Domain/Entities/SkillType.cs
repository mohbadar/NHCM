using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Domain.Entities
{
  public  class SkillType
    {
        public SkillType()
        {
            InverseParent = new HashSet<SkillType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual SkillType Parent { get; set; }
        public virtual ICollection<SkillType> InverseParent { get; set; }
    }
}

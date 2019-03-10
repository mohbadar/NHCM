using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Certification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SkillTypeId { get; set; }

        public virtual SkillType SkillType { get; set; }
    }
}

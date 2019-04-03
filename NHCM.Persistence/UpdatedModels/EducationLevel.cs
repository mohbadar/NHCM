using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class EducationLevel
    {
        public EducationLevel()
        {
            Education = new HashSet<Education>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? Parentid { get; set; }
        public string Sorter { get; set; }

        public virtual ICollection<Education> Education { get; set; }
    }
}

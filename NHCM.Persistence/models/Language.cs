using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class Language
    {
        public Language()
        {
            PersonLanguage = new HashSet<PersonLanguage>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public virtual ICollection<PersonLanguage> PersonLanguage { get; set; }
    }
}

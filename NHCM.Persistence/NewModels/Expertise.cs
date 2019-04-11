using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Expertise
    {
        public Expertise()
        {
            PersonLanguageReadingExpertiseNavigation = new HashSet<PersonLanguage>();
            PersonLanguageSpeakingExpertiseNavigation = new HashSet<PersonLanguage>();
            PersonLanguageUnderstandingExpertiseNavigation = new HashSet<PersonLanguage>();
            PersonLanguageWritingExpertiseNavigation = new HashSet<PersonLanguage>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonLanguage> PersonLanguageReadingExpertiseNavigation { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguageSpeakingExpertiseNavigation { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguageUnderstandingExpertiseNavigation { get; set; }
        public virtual ICollection<PersonLanguage> PersonLanguageWritingExpertiseNavigation { get; set; }
    }
}

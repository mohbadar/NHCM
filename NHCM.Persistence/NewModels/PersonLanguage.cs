using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class PersonLanguage
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public short LanguageId { get; set; }
        public short? ReadingExpertise { get; set; }
        public short? UnderstandingExpertise { get; set; }
        public short? WritingExpertise { get; set; }
        public short? SpeakingExpertise { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Person Person { get; set; }
    }
}

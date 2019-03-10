using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            PersonDocument = new HashSet<PersonDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonDocument> PersonDocument { get; set; }
    }
}

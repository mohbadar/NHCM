﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Person = new HashSet<Person>();
            PersonDocument = new HashSet<PersonDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ScreenId { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonDocument> PersonDocument { get; set; }
    }
}

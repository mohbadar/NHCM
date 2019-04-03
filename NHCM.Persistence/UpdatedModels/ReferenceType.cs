using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class ReferenceType
    {
        public ReferenceType()
        {
            Reference = new HashSet<Reference>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reference> Reference { get; set; }
    }
}

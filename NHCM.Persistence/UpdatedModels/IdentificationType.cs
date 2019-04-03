using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class IdentificationType
    {
        public IdentificationType()
        {
            PersonIdentification = new HashSet<PersonIdentification>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonIdentification> PersonIdentification { get; set; }
    }
}

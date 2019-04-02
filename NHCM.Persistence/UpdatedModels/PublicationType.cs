using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class PublicationType
    {
        public PublicationType()
        {
            Publication = new HashSet<Publication>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Publication> Publication { get; set; }
    }
}

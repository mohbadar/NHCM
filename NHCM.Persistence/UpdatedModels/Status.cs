using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Status
    {
        public Status()
        {
            Owner = new HashSet<Owner>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Owner> Owner { get; set; }
    }
}

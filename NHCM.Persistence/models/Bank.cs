using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class Bank
    {
        public Bank()
        {
            Reference = new HashSet<Reference>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reference> Reference { get; set; }
    }
}

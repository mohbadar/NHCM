using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class MilitaryServiceType
    {
        public MilitaryServiceType()
        {
            MilitaryService = new HashSet<MilitaryService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MilitaryService> MilitaryService { get; set; }
    }
}

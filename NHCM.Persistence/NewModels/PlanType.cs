using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class PlanType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public char Code { get; set; }
        public short? ParentId { get; set; }
    }
}

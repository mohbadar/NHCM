using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class OrgUnitType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short? Parentid { get; set; }
        public bool? Ishead { get; set; }
    }
}

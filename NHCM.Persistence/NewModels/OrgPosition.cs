using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class OrgPosition
    {
        public int PositionTypeId { get; set; }
        public int OrgUnitTypeId { get; set; }
        public int? ParentId { get; set; }
        public short Id { get; set; }
        public short RankId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class OrgUnitType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }
        public bool? IsHead { get; set; }
    }
}

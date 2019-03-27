﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Domain.Entities
{
    public class PositionType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }
        public short? RankId { get; set; }
        public char? Code { get; set; }
        public short? OrgUnitTypeId { get; set; }
        public bool? IsUnit { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class PositionChange
    {
        public decimal Id { get; set; }
        public int OrganogramId { get; set; }
        public decimal PositionId { get; set; }
        public short PlanTypeId { get; set; }
        public bool? IsAddition { get; set; }
        public string Name { get; set; }
        public decimal? NewPositionId { get; set; }

        public virtual OrganoGram Organogram { get; set; }
        public virtual Position Position { get; set; }
    }
}

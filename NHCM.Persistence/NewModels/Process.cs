﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Predecessor { get; set; }
        public int Successor { get; set; }
        public int ScreenId { get; set; }
        public int OnSuccessStatus { get; set; }
        public int OnFailureStatus { get; set; }
    }
}

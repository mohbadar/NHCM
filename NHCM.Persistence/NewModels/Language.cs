﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Language
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Category
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public char Code { get; set; }
    }
}
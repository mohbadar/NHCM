﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class FileLocation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
    }
}

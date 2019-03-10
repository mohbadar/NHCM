using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class Status
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }
    }
}

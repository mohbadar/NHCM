using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pastho { get; set; }
    }
}

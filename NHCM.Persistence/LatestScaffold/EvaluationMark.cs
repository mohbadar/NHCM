using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestScaffold
{
    public partial class EvaluationMark
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public char Category { get; set; }
        public short Weight { get; set; }
    }
}

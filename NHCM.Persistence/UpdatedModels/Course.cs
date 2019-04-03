using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public char? Category { get; set; }
    }
}

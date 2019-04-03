using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Location
    {
        public int Id { get; set; }
        public string Dari { get; set; }
        public int IsActive { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public string PathDari { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
    }
}

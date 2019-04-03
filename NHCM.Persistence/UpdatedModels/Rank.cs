using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Rank
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public string Sorter { get; set; }
        public short? CategoryId { get; set; }
        public int? Rate { get; set; }
        public int? Code { get; set; }
        public string RankNumber { get; set; }
        public short? ParentId { get; set; }
        public char? Type { get; set; }
    }
}

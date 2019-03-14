using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }
        public short OrganizationTypeId { get; set; }
        public string Code { get; set; }
        public short StatusId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ReferenceNo { get; set; }
        public bool? IsInitiated { get; set; }
        public string Sorter { get; set; }
        public decimal? ParentId { get; set; }
        public short? AndssectorId { get; set; }
        public string StrategicObject { get; set; }
        public string KeyOutCome { get; set; }
        public string KeyOutComeDari { get; set; }
    }
}

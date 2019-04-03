using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class Event
    {
        public decimal Id { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int StatusId { get; set; }
        public int? OrganizationId { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string DocumentNo { get; set; }
        public string Remarks { get; set; }
        public int? EventTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class OrganoGram
    {
        public OrganoGram()
        {
            OrgUnitChange = new HashSet<OrgUnitChange>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public short StatusId { get; set; }
        public string ReferenceNo { get; set; }
        public int? Year { get; set; }
        public int? NumberOfPositions { get; set; }
        public int? IsPositionsCopied { get; set; }

        public virtual ICollection<OrgUnitChange> OrgUnitChange { get; set; }
    }
}

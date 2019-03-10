﻿using System;
using System.Collections.Generic;

namespace NHCM.Persistence.LatestDb
{
    public partial class OrganoGram
    {
        public OrganoGram()
        {
            OrgUnit = new HashSet<OrgUnit>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public short StatusId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ReferenceNo { get; set; }
        public int? Year { get; set; }
        public DateTime? PreparedDate { get; set; }
        public DateTime? AppreovedDate { get; set; }

        public virtual ICollection<OrgUnit> OrgUnit { get; set; }
    }
}

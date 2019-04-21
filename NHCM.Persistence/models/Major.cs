using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class Major
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short? TrainingTypeId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TrainingType TrainingType { get; set; }
    }
}

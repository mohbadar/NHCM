using System;
using System.Collections.Generic;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class PersonCharacteristic
    {
        public decimal Id { get; set; }
        public decimal PersonId { get; set; }
        public string Characteristic { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string Value { get; set; }

        public virtual Person Person { get; set; }
    }
}

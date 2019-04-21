using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class RewardType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public string BenefitForSocialWorker { get; set; }
        public string BenefitForMilitaryWorker { get; set; }
        public string TypeOfMetal { get; set; }
        public char? Type { get; set; }
    }
}

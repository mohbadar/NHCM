using System;
using System.Collections.Generic;

namespace NHCM.Persistence.models
{
    public partial class AssetType
    {
        public AssetType()
        {
            InverseParent = new HashSet<AssetType>();
            PersonAsset = new HashSet<PersonAsset>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }

        public virtual AssetType Parent { get; set; }
        public virtual ICollection<AssetType> InverseParent { get; set; }
        public virtual ICollection<PersonAsset> PersonAsset { get; set; }
    }
}

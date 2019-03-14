using System;
using System.Collections.Generic;

namespace NHCM.Persistence.NewModels
{
    public partial class FolderPath
    {
        public int Id { get; set; }
        public string SettingsKey { get; set; }
        public string CurrentFolder { get; set; }
    }
}

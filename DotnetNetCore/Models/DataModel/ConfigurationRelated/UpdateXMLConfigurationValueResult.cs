using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.ConfigurationRelated
{
    public class UpdateXMLConfigurationValueResult
    {
        public string SettingFileKey { get; set; }
        public bool IsModifiedSuccessfully { get; set; }
        public string ModifiedValue { get; set; }
    }
}

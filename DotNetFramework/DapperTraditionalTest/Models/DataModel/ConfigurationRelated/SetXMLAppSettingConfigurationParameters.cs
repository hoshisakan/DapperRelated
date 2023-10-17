using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModel.ConfigurationRelated
{
    public class SetXMLAppSettingConfigurationParameters
    {
        public string? SettingFileKey { get; set; }
        public string? JobName { get; set; }
        public string? JobCurrentLoadLogDate { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}

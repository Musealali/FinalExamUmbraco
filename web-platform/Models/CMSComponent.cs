using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class CMSComponent
    {
        public string Version { get; set; }
        public string Name { get; set; }

        public CMSComponent()
        {

        }
        public CMSComponent(string version, string name)
        {
            Version = version;
            Name = name;
        }
    }
}

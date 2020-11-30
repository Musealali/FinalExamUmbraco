using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Data.Models
{
    public class ComponentVersion
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; }
        public ICollection<CMSComponent> CMSComponents { get; set; }
        public ICollection<CMSComponentVersion> CMSComponentVersions { get; set; }
        public ComponentVersion()
        {

        }
        public ComponentVersion(string versionNumber)
        {
            VersionNumber = versionNumber; 
        }
    }
}

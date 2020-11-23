using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class Version
    {
        [Key]
        public string VersionNumber { get; set; }

       public Version()
        {

        }
        public Version(string versionNumber)
        {
            VersionNumber = versionNumber; 
        }
    }
}

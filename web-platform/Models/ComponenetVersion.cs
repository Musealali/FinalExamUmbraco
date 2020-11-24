using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class ComponenetVersion
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; }

       public ComponenetVersion()
        {

        }
        public ComponenetVersion(string versionNumber)
        {
            VersionNumber = versionNumber; 
        }
    }
}

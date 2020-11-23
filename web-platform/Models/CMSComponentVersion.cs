using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class CMSComponentVersion
    {
        public int Id { get; set; }
        public CMSComponent CMSComponent { get; set; }
        public Version Version { get; set; }
    }
}

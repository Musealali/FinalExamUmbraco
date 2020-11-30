using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Data.Models
{
    public class CMSComponentVersion
    {
        public int Id { get; set; }
        public CMSComponent CMSComponent { get; set; }
        public int CMSComponentId { get; set; }
        public ComponentVersion Version { get; set; }
        public int ComponentVersionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class CMSComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CMSComponentVersion> CMSComponentVersions { get; set; }
        public CMSComponent()
        {
            
        }
        public CMSComponent(string name)
        {
            Name = name;
        }
    }
}

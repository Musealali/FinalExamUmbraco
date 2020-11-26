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
        public enum ComponentType { CMS, Package }
        public int Id { get; set; }
        public string Name { get; set; }
        public ComponentType CType { get; set; } 
        public ICollection<ComponentVersion> Versions { get; set; }
        public ICollection<CMSComponentVersion> CMSComponentVersions { get; set; }
        public CMSComponent()
        {
            
        }
        public CMSComponent(string name, ComponentType cType)
        {
            Name = name;
            CType = cType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Data.Models
{
    public enum ComponentType { CMS, Package }
    public class CMSComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ComponentType ComponentType { get; set; } 
        public ICollection<ComponentVersion> Versions { get; set; }
        public ICollection<CMSComponentVersion> CMSComponentVersions { get; set; }
        public CMSComponent()
        {
            
        }
        public CMSComponent(string name, ComponentType componentType)
        {
            Name = name;
            ComponentType = componentType;
        }
    }
}

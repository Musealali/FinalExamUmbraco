using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Models
{
    public class CreateSecurityIssueViewModel
    {
        public List<CMSComponent> MultipleCMS { get; set; }
        public List<CMSComponent> Packages { get; set; }
        public List<ComponentVersion> FormsVersions { get; set; }
        public List<ComponentVersion> USyncVersions { get; set; }
        public List<ComponentVersion> UmbracoCMSVersions { get; set; }
        public List<ComponentVersion> UmbracoUNOVersions { get; set; }
        public List<ComponentVersion> UmbracoHeartcoreVersions { get; set; }
    }
}

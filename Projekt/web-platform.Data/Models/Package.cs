using System;
using System.Collections.Generic;
using System.Text;

namespace web_platform.Data.Models
{
    public class Package
    {
        public string Category { get; set; }
        public string Created { get; set; }
        public int Downloads { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string LatestVersion { get; set; }
        public int Likes { get; set; }
        public string Name { get; set; }
        public OwnerInfo OwnerInfo { get; set; }
        public int Score { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public string VersionRange { get; set; }
    }
}

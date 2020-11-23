using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_platform.Models
{
    public class Package : CMSComponent
    {
        public Package()
        {

        }

        public Package(string name, string version) : base(name, version)
        {

        }
    }
}

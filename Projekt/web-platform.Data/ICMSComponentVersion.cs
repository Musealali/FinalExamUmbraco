using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public interface ICMSComponentVersion
    {
        Task<CMSComponentVersion> GetCMSComponentVersion(string name, string version, string componentType);
    }
}

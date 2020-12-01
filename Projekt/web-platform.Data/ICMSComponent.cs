using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public interface ICMSComponent
    {
        Task<List<CMSComponent>> GetCMSComponentsByType(ComponentType componentType);
        ComponentType GetComponentTypeCMS();
        ComponentType GetComponentTypePackage();
    }
}

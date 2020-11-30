using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public interface IComponentVersion
    {
        Task<List<ComponentVersion>> GetComponentVersionByComponentName(string componentName);
    }
}

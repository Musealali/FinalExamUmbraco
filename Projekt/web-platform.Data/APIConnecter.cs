using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using web_platform.Data.Models;

namespace web_platform.Data
{
    public class ApiConnecter
    {
        public HttpClient Client { get; set; } = new HttpClient();

        public async Task<string> GetPackages()
        {
            var result = await Client.GetStringAsync("https://our.umbraco.com/webapi/packages/v1?pageIndex=0&pageSize=10000&category=&query=testing&order=Default%22");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            var json = JsonConvert.SerializeXmlNode(doc);
            var data = JsonConvert.DeserializeObject<PagedPackages>(json);
            List<string> packageNames = new List<string>();
            foreach (Package packages in data.Packages)
            {
                packageNames.Add(packages.Name);
            }
            return json;
        }
    }
}

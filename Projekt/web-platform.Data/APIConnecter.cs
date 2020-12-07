using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var data = JsonConvert.DeserializeObject<MyJsonType>(json);
            //var myJObject = JObject.Parse(json);
            //var myList = myJObject.SelectTokens("$.PagedPackages.Packages.Package").Value<JObject>().ToList();
            Console.WriteLine("test");
            return json;
        }
    }
}

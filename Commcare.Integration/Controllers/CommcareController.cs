using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace Commcare.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommcareController : Controller
    {
        [HttpGet("process")]
        public IActionResult ProcessJson()
        {
            string url = "https://www.commcarehq.org/a/palladium-1/api/v0.5/form/";
            string username = "kennedy.kirui@thepalladiumgroup.com";
            string password = "Teket2010!";

            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(url),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = Encoding.UTF8.GetBytes(username + ":" + password);
            string val = Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            string json = string.Empty;

            using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, Encoding.UTF8))
            {
                json = stream.ReadToEnd();
            }

            List<JToken> children = JObject.Parse(json).Descendants().Where(x => x.Type == JTokenType.Property && x.HasValues == true).ToList();
            //JArray token = Flatten(json);

            return Ok(new { message = "Updated successfully" });
        }

        public static JArray Flatten(string json)
        {
            JObject jo = JObject.Parse(json);
            JToken input = jo.Descendants()
                .Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == "objects")
                .Select(p => ((JProperty)p).Value)
                .FirstOrDefault();

            //JToken input = JToken.Parse(json);
            var res = new JArray();
            foreach (var obj in GetFlattenedObjects(input))
                res.Add(obj);
            return res;
        }

        public static IEnumerable<JToken> GetFlattenedObjects(JToken token, IEnumerable<JProperty> OtherProperties = null)
        {
            if (token is JObject obj)
            {
                var children = obj.Children<JProperty>().GroupBy(prop => prop.Value?.Type == JTokenType.Array).ToDictionary(gr => gr.Key);
                if (children.TryGetValue(false, out var directProps))
                    OtherProperties = OtherProperties?.Concat(directProps) ?? directProps; //NB, no checks if any sub collection contains duplicate prop names

                if (children.TryGetValue(true, out var ChildCollections))
                {
                    foreach (var childObj in ChildCollections.SelectMany(childColl => childColl.Values()).SelectMany(childColl => GetFlattenedObjects(childColl, OtherProperties)))
                        yield return childObj;
                }
                else //no (more) child properties, return an object
                {
                    var res = new JObject();
                    if (OtherProperties != null)
                        foreach (var prop in OtherProperties)
                            res.Add(prop);
                    yield return res;
                }
            }
            else if (token is JArray arr)
            {
                foreach (var co in token.Children().SelectMany(c => GetFlattenedObjects(c, OtherProperties)))
                    yield return co;
            }
            else
                throw new NotImplementedException(token.GetType().Name);


        }
    }
}

using Commcare.Integration.Entities;
using Commcare.Integration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Text;

namespace Commcare.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommcareController : Controller
    {
        private readonly FormDataService _formDataService;
        private readonly PullHistoryService _pullHistoryService;
        private readonly string baseUrl = "https://www.commcarehq.org/a/palladium-1/api/v0.5/form/";
        private readonly string username = "kennedy.kirui@thepalladiumgroup.com";
        private readonly string password = "Teket2010!";

        public CommcareController(FormDataService formDataService, PullHistoryService pullHistoryService)
        {
            _formDataService = formDataService;
            _pullHistoryService = pullHistoryService;
        }

        [HttpGet("new-records")]
        public IActionResult DownloadNewRecords()
        {
            //get last execution time
            PullHistory history = _pullHistoryService.GetLastRecord();
            string lastExecution = history.CreateDate.ToString("yyyy-MM-ddTHH:mm:ss");

            //download
            string url = baseUrl + "?limit=200&received_on_start=" + lastExecution;
            string json = DownloadData(url);

            //process json and save
            ProcessData(json);

            //Save pull history
            _pullHistoryService.Save(new PullHistory { PullDate=DateTime.Now, PullStatus="Success" });

            return Ok(new { message = "Downloaded successfully" });
        }

        [HttpGet("old-records")]
        public IActionResult DownloadOldRecords()
        {
            //download
            string url = baseUrl + "?limit=1000";
            string json = DownloadData(url);

            //process json and save
            ProcessData(json);

            //Save pull history
            _pullHistoryService.Save(new PullHistory { PullDate = DateTime.Now, PullStatus = "Success" });

            return Ok(new { message = "Downloaded successfully" });
        }

        private string DownloadData(string url)
        {
            HttpMessageHandler handler = new HttpClientHandler()
            {
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(url),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            var plainTextBytes = Encoding.UTF8.GetBytes(username + ":" + password);
            string val = Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            string json = string.Empty;

            using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, Encoding.UTF8))
            {
                json = stream.ReadToEnd();
            }

            return json;
        }

        private bool ProcessData(string json)
        {
            List<FormData> formdata = new List<FormData>();

            try
            {
                //Save received json string
                Commcare commcare = JsonConvert.DeserializeObject<Commcare>(json);
                foreach (object obj in commcare.objects)
                {
                    List<JToken> DataValues = JObject.Parse(obj.ToString()).Descendants().Where(x => x.HasValues == false).ToList();

                    JToken Id = DataValues.Where(x => x.Path == "id").FirstOrDefault();
                    JToken appId = DataValues.Where(x => x.Path == "app_id").FirstOrDefault();

                    foreach (JToken dataValue in DataValues)
                    {
                        FormData data = new FormData();
                        data.FormId = Id.ToString();
                        data.FieldName = dataValue.Path;
                        data.FieldValue = dataValue.ToString();
                        data.AppId = appId.ToString();

                        formdata.Add(data);
                    }
                }

                _formDataService.Save(formdata);

                return true;
            }
            catch
            { 
                return false;
            }
        }
    }
}

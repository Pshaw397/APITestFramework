using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_App
{
    public class GetOutcodeService
    {
        // Properties
        public RestClient Client;
        public IRestResponse RestResponse { get; set; }
        public JObject ResponseContent;
        public OutcodeResponse ResponseObject { get; set; }
        public string OutcodeSelected { get; set; }

        public GetOutcodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequestAsync(string outcode)
        {
            // set up the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            OutcodeSelected = outcode;

            // define request resource path, changing to lowercase and removing whitespace
            request.Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}";

            // make request
            RestResponse = await Client.ExecuteAsync(request);

            // parse json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);

            // parse response body into an object tree
            ResponseObject = JsonConvert.DeserializeObject<OutcodeResponse>(RestResponse.Content);
        }
    }
}

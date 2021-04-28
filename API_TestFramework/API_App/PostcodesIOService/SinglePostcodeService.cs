using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class SinglePostcodeService
    {
        #region Properties
        // Restsharp object which handles communicaiton with the API
        public RestClient Client;
        // Restsharp response object
        public IRestResponse RestResponse { get; set; }
        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent;
        // An object model of the response
        public SinglePostcodeResponse ResponseObject { get; set; }
        // the postcode used in this API request
        public string PostcodeSelected { get; set; }
        #endregion

        // constructor - creates the RestClient object
        public SinglePostcodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequestAsync (string postcode)
        {
            // set up the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;

            // define request resource path, changing to lowercase and removing whitespace
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            // make request
            RestResponse = await Client.ExecuteAsync(request);

            // parse json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);

            // parse response body into an object tree
            ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(RestResponse.Content);
        }
    }
}

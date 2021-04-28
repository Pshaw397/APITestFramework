using System;
using System.Threading.Tasks;
using RestSharp;

namespace API_App.PostcodesIOService
{
    public class CallManager
    {
        // Restsharp object which handles communication with the API
        readonly IRestClient _client;

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }

        /// <summary>
        /// defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns>The response content</returns>
        public async Task<string> MakePostcodeRequest(string postcode)
        {
            // set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "applicaton/json");

            // define request resource path, changing to lowercase and removing whitespace
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            // make request
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}

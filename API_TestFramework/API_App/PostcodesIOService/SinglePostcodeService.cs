using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace API_App.PostcodesIOService
{
    public class SinglePostcodeService
    {
        #region Properties
        public CallManager CallManager { get; }
        // A Newtonsoft object representing the JSON response
        public JObject ResponseContent;
        // An object model of the response
        public SinglePostcodeDTO SinglePostcodeDTO { get; set; }
        // the postcode used in this API request
        public string PostcodeSelected { get; set; }
        // the response content as a string
        public string PostcodeResponse { get; set; }
        #endregion

        // constructor - creates the RestClient object
        public SinglePostcodeService()
        {
            CallManager = new CallManager();
            SinglePostcodeDTO = new SinglePostcodeDTO();
        }

        public async Task MakeRequestAsync (string postcode)
        {
            PostcodeSelected = postcode;

            // make request
            PostcodeResponse = await CallManager.MakePostcodeRequest(postcode);

            // parse json into a JObject
            ResponseContent = JObject.Parse(PostcodeResponse);

            // parse response body into an object tree
            SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
        }
    }
}

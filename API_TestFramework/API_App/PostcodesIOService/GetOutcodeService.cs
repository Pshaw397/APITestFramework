using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace API_App.PostcodesIOService
{
    public class GetOutcodeService
    {
        // Properties
        public CallManager CallManager { get; }
        public JObject ResponseContent;
        public OutcodeDTO OutcodeDTO { get; set; }
        public string OutcodeSelected { get; set; }
        public string OutcodeResponse { get; set; }

        public GetOutcodeService()
        {
            CallManager = new CallManager();
            OutcodeDTO = new OutcodeDTO();
        }

        public async Task MakeRequestAsync(string outcode)
        {
            OutcodeSelected = outcode;

            // make request
            OutcodeResponse = await CallManager.MakeOutcodeResponse(outcode);

            // parse json into a JObject
            ResponseContent = JObject.Parse(OutcodeResponse);

            // parse response body into an object tree
            OutcodeDTO.DeserializeResponse(OutcodeResponse);
        }
    }
}

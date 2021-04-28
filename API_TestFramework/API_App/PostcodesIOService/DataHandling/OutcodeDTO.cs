using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class OutcodeDTO
    {
        public OutcodeResponse OutcodeResponse { get; set; }
        public void DeserializeResponse(string outcodeResponse)
        {
            OutcodeResponse = JsonConvert.DeserializeObject<OutcodeResponse>(outcodeResponse);
        }
    }
}

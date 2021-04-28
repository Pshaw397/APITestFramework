using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class SinglePostcodeDTO
    {
        public SinglePostcodeResponse SinglePostcodeResponse { get; set; }
        public void DeserializeResponse(string postcodeResponse)
        {
            SinglePostcodeResponse = JsonConvert.DeserializeObject<SinglePostcodeResponse>(postcodeResponse);
        }
    }
}

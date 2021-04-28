using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using API_App.PostcodesIOService;

namespace API_App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Here we are creating a RestClient, which holds that base URL of the API
            var restClient = new RestClient("https://api.postcodes.io/");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            // This is setting the header for the REQUEST "Content-Type" to "application/json"
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            var postcode = "EC2Y 5AS";
            // The resource is the unique information we put in for the request are are putting through
            // Here we are adding the extra URL part, making the input postcode lowercase, and removing and spaces in the string
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            var restResponse = await restClient.ExecuteAsync(restRequest);
            Console.WriteLine("Response content (string):");
            Console.WriteLine(restResponse.Content);

            // This converts our retrived response and converts it into a JObject which formats the JSON response
            var jsonResponse = JObject.Parse(restResponse.Content);
            Console.WriteLine("\nResponse content as a JOjbect");
            Console.WriteLine(jsonResponse);

            // we are setting adminDistrct to the jsonResult we specified previously, however only the information relating to "admin_district"
            var adminDistrict = jsonResponse["result"]["admin_district"];
            Console.WriteLine($"Admin district: {adminDistrict}");

            var adminDistrictCode = jsonResponse["result"]["codes"]["admin_district"];
            Console.WriteLine($"Admin district code: {adminDistrictCode}");

            var singlePostCodeResponse = JsonConvert.DeserializeObject<SinglePostcodeResponse>(restResponse.Content);

            // This is the snippet of code from postman that we copied and pasted into here
            // This is doing the same thing as the previous statement, however is more hard coded
            var client = new RestClient("https://api.postcodes.io/postcodes/EC2Y5AS");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "__cfduid=d7baef6a529cb3b6378a1adbf3e92e6341619520401");
            IRestResponse response = client.Execute(request);
            Console.WriteLine("Response from Postman generated GET request");
            Console.WriteLine(response.Content);

            var clientPost = new RestClient("https://api.postcodes.io/postcodes/");
            client.Timeout = -1;
            var requestPost = new RestRequest(Method.POST);
            requestPost.AddHeader("Content-Type", "application/json");
            requestPost.AddHeader("Cookie", "__cfduid=d7baef6a529cb3b6378a1adbf3e92e6341619520401");
            requestPost.AddParameter("application/json", "{\r\n    \"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}", ParameterType.RequestBody);
            IRestResponse responsePost = clientPost.Execute(requestPost);
            //Console.WriteLine("Response from Postman generated POST request");
            //Console.WriteLine(responsePost.Content);

            var bulkJsonResponse = JObject.Parse(responsePost.Content);
            //Console.WriteLine("\nResponse from Postman generated POST request as a JOjbect");
            //Console.WriteLine(bulkJsonResponse);

            var adminDistrictPost = bulkJsonResponse["result"][1]["result"]["admin_district"];
            //Console.WriteLine($"Admin district: {adminDistrictPost}");

            var bulkPostcodeResponse = JsonConvert.DeserializeObject<BulkPostcodeResult>(responsePost.Content);
            var adminDistrictFromBPR = bulkPostcodeResponse.result[1].result.admin_district;
            Console.WriteLine($"\nAdmin District Bulk Deserialized: {adminDistrictFromBPR}");
            Console.WriteLine($"Postcode 1 Parish: {bulkPostcodeResponse.result[0].result.parish}");
            Console.WriteLine($"Postcode 2 Parish: {bulkPostcodeResponse.result[2].result.parish}");
        }
    }
}

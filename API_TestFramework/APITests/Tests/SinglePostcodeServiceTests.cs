using NUnit.Framework;
using System.Threading.Tasks;
using API_App.PostcodesIOService;

namespace APITests.Tests
{
    public class WhenTheSinglePostCodeServiceIsCalled_WithValidPostcodes
    {
        SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequestAsync("EC2Y 5AS");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void CorrectPostCodeIsReturned()
        {
            var result = _singlePostcodeService.ResponseContent["result"]["postcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y 5AS"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singlePostcodeService.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.ResponseObject.result.admin_district, Is.EqualTo("City of London"));
        }
    }
}

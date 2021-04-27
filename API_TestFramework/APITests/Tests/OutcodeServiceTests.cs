using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using API_App;
using System.Threading.Tasks;

namespace APITests.Tests
{
    public class WhenTheOutcodeServiceIsCalled_WithValidOutcodes
    {
        GetOutcodeService _outcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _outcodeService = new GetOutcodeService();
            await _outcodeService.MakeRequestAsync("OX49");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_outcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void CorrectPostCodeIsReturned()
        {
            var result = _outcodeService.ResponseContent["result"]["admin_district"][0].ToString();
            Assert.That(result, Is.EqualTo("South Oxfordshire"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_outcodeService.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistrict_SouthOxforshire()
        {
            Assert.That(_outcodeService.ResponseObject.result.admin_district[0], Is.EqualTo("South Oxfordshire"));        
        }

        [Test]
        public void EastingsNoIs_469203()
        {
            Assert.That(_outcodeService.ResponseObject.result.eastings, Is.EqualTo(469203));
        }
    }
}

using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using API_App;

namespace APITests.Tests
{
    public class WhenTheSinglePostCodeServiceIsCalled_WithValidPostcodes
    {
        SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _singlePostcodeService = new SinglePostcodeService();
            _singlePostcodeService.MakeRequest("EC2Y 5AS");
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
    }
}

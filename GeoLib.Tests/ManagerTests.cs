using GeoLib.Data;
using GeoLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeoLib.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void test_zip_code_retrieval()
        {
            var mockZipCodeRepository = new Mock<IZipCodeRepository>();

            var zipCode = new ZipCode
            {
                City = "LINCOLN PARK",
                State = new State {Abbreviation = "NJ"},
                Zip = "07035"
            };

            mockZipCodeRepository.Setup(repository => repository.GetByZip("07035")).Returns(zipCode);
            var geoService = new GeoManager(mockZipCodeRepository.Object);
            var data = geoService.GetZipInfo("07035");
            
            Assert.IsTrue(data.City.ToUpper() == "LINCOLN PARK");
            Assert.IsTrue(data.State == "NJ");
        }
    }
}
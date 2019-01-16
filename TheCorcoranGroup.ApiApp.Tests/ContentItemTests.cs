using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TheCorcoranGroup.ApiApp.Tests.Builders;

namespace TheCorcoranGroup.ApiApp.Tests
{
    [TestClass]
    public class ContentItemTests
    {
        [TestMethod]
        public void GetAllPresidents_Good_Found()
        {
            //Arrange
            ContentItemBuilder builder = new ContentItemBuilder();
            var controller = builder.SetupController();

            //Act
            var result = controller.GetAllPresidents();

            //Assert
            JObject jObject = JObject.Parse(result.Content.ReadAsStringAsync().Result);
            var success = jObject["Success"].ToString();
            Assert.IsTrue(result.StatusCode == HttpStatusCode.OK, "Expected OK status");
            Assert.IsTrue(success == "True", "Expected Success True");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Telerik.JustMock;
using TheCorcoranGroup.ApiApp.Controllers;
using TheCorcoranGroup.ApiApp.Services;
using TheCorcoranGroup.Data;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.ApiApp.Tests.Builders
{
    public class ContentItemBuilder
    {
        public ContentItemBuilder()
        {
        }

        public ContentItemController SetupController()
        {
            var contentService = Mock.Create<IContentItemService>();
            var contentRepo = Mock.Create<IContentItemRepository>();

            var controller = new ContentItemController(contentService);

            Mock.Arrange(() => contentService.GetAllPresidents()).Returns(new List<PresidentModel> { new PresidentModel { id = 1} });

            controller.Request = this.GetRequest();

            return controller;
        }

        public HttpRequestMessage GetRequest()
        {
            var baseRequest = Mock.Create<HttpRequestMessage>();
            baseRequest.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            baseRequest.SetRouteData(new HttpRouteData(new HttpRoute("Test Route")));
            return baseRequest;
        }
    }
}

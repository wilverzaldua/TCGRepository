using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using TheCorcoranGroup.ApiApp.Models;
using TheCorcoranGroup.ApiApp.Services;
using TheCorcoranGroup.Data;
using TheCorcoranGroup.Model;

namespace TheCorcoranGroup.ApiApp.Controllers
{
    [ApiVersion("1", Deprecated = true)]
    [ApiVersion("2")]
    [RoutePrefix("api/content/v{version:apiVersion}")]
    public class ContentItemController : ApiController
    {
        private readonly IContentItemService _contentItemService;
        private readonly IContentItemRepository _contentItemRepository;

        public ContentItemController()
        {
            _contentItemRepository = new ContentItemRepository();
            _contentItemService = new ContentItemService(_contentItemRepository);
        }

        public ContentItemController(IContentItemService contentItemService)
        {
            _contentItemService = contentItemService;
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("")]
        public HttpResponseMessage Index()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "The Corcoran Group Api");
        }

        [HttpGet, MapToApiVersion("2")]
        [Route("presidents")]
        [ResponseType(typeof(ContentItemApiResponse))]
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage GetAllPresidents()
        {
            IEnumerable<PresidentModel> presidents = _contentItemService.GetAllPresidents();

            ContentItemApiResponse response = new ContentItemApiResponse
            {
                Success = true,
                Data = Newtonsoft.Json.JsonConvert.SerializeObject(presidents),
                Messages = "OK"
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}

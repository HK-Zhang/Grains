using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstOwinWebApi.Controllers
{
    [RoutePrefix("api/HelloWorld")]
    public class HelloWorldController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post()
        {

            return Ok<string>("Hello World");

        }

    }
}

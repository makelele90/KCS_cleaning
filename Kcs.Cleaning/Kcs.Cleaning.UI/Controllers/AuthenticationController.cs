using Kcs.Cleaning.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kcs.Cleaning.UI.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage LogIn(UserModel value)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent("ok");


            return response;
        }

    }
}

using Kcs.Cleaning.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kcs.Cleaning.DAL.Repository;
using Kcs.Cleaning.Services.Classes;
using Kcs.Cleaning.Services.Interfaces;

namespace Kcs.Cleaning.UI.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IUserService _userService;
        public AuthenticationController()
        {
            _userService=new UserService(new UserRepository());
        }
        [HttpPost]
        public HttpResponseMessage LogIn(UserModel user)
        {
            HttpResponseMessage response = null;
            var result = _userService.Login(user.UserName, user.Password);

            if(result)
                response = new HttpResponseMessage() {StatusCode = HttpStatusCode.OK, Content = new StringContent("ok")};
            else
            {
                response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent("") };
            }

            return response;
        }
        
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kcs.Cleaning.Datacontainer.DTO;
using Kcs.Cleaning.DAL.Repository;
using Kcs.Cleaning.Services.Classes;
using Kcs.Cleaning.Services.Interfaces;
using Kcs.Cleaning.UI.Models;

namespace Kcs.Cleaning.UI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService(new UserRepository());
        }
        // GET api/user
        public HttpResponseMessage Get()
        {
            var users = _userService.FindAll();

            var userModels = users.ToList().Select(u => new UserModel()
            {
                UserName = u.Username,
                FirstName = u.Profile!=null?u.Profile.FirstName:string.Empty,
                LastName = u.Profile != null ? u.Profile.LastName : string.Empty,
                CreatedOn = u.CreatedOn
            });

            var response = Request.CreateResponse<IEnumerable<UserModel>>(HttpStatusCode.OK, userModels);

            return response;
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public HttpResponseMessage Post(UserModel userModel)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("error")
            };

            var user = new UserDto
            {
                UserName = userModel.UserName,
                Password = userModel.Password,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
          var result=  _userService.CreateUser(user);

            if (result)
            {
                responseMessage.StatusCode = HttpStatusCode.Created;
                responseMessage.Content=new StringContent("ok");
            }


            return responseMessage;

        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}

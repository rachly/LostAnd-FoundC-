using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DAL;
using DTO;


namespace API.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class UserController : ApiController
    {
        UserService service = new UserService();

        [HttpPost]
        [Route("~/api/user/addUser")]
        public IHttpActionResult addUser(UserDTO user)
        {
            if (user == null)
                return NotFound();
            return Ok(service.AddUser(user));
        }


        [HttpGet]
        public int GetAllUsers()
        {
            return service.getAllUsers();
        }
        [HttpDelete]
        public IHttpActionResult DeleteUser(int userId)
        {
            if (userId == 0)

                return NotFound();
            return Ok(service.UpdateUser(userId));

        }
        [HttpPost]
        [Route("~/api/user/IsUser")]

        public UserDTO IsUser(users u)
        {
            return service.IsUser(u);
        }
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public class EmailController : ApiController
        {
            EmailService email = new EmailService();
            [HttpGet]
            public bool UserAdmin()
            {
                return email.emailsend();
            }

        }
        [HttpPost]
        public IHttpActionResult EmailUser(int userId,int c)
        {
            if (userId == 0)
                return NotFound();
            return Ok(service.UserEmailService(userId,c));
        }

    }
}

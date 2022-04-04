
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using projectServices.Context;
using projectServices.Models;

namespace projectServices.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private LoginContext _loginContext;

        public LoginController(LoginContext loginContext)
        {
            _loginContext = loginContext;
        }



        //GET : api/<UserController>/Phone
        [HttpGet("{Phone}/{Password}")]
        public Login Get(string Phone, string Password)
        {
            return _loginContext.login.FirstOrDefault(s => s.LoginPhone == Phone && s.LoginPassword == Password);
        }


    }
}
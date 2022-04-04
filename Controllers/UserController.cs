namespace projectServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using projectServices.Context;
    using projectServices.Models;




    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersContext _usersContext;

        public UsersController(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }


        [HttpGet]
        //GET : api/<UsersController>
        public IEnumerable<Users> Get()
        {
            return _usersContext.users;
        }

        //GET : api/<UserController>/Phone
        [HttpGet("{Phone}")]
        public Users Get(string Phone)
        {
            return _usersContext.users.FirstOrDefault(s => s.Phone == Phone);
        }






        //POST : api/<UserController>
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            _usersContext.users.Add(value);
            _usersContext.SaveChanges();
        }


        // BAK BURAYYA
        //PUT : api/<UserController>/Phone
        [HttpPut("{Phone}")]
        public void Put(string Phone, [FromBody] Users value)
        {
            var tempUsers = _usersContext.users.FirstOrDefault(s => s.Phone == Phone);

            if (tempUsers != null)
            {
                _usersContext.Entry<Users>(tempUsers).CurrentValues.SetValues(value);
                _usersContext.SaveChanges();

            }
        }

        //DELETE : api/<UserController>/Phone
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var tempUsers = _usersContext.users.FirstOrDefault(s => s.Id == Id);

            if (tempUsers != null)
            {
                _usersContext.users.Remove(tempUsers);
                _usersContext.SaveChanges();
            }
        }

    }


}
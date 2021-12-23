using Microsoft.AspNetCore.Mvc;
using RT.Contacts.Domain.Interfaces;
using RT.Contacts.Domain.Models;
using RT.Contacts.ResultType;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT.Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBL _userBL;
        public UserController(IUserBL userInormationBL)
        {
            _userBL = userInormationBL;
        }

        // GET: api/<UserController>
        [HttpGet]
        public Result<List<UserDO>> Get()
        {
            return _userBL.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Result<UserDO> Get(int id)
        {
            return _userBL.GetByID(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public Result<UserDO> Add([FromBody] UserDO model)
        {
            return _userBL.Add(model);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public Result<UserDO> Update(int id, [FromBody] UserDO model)
        {
            return _userBL.Update(model);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public Result<bool> Delete(int id)
        {
            return _userBL.Delete(id);
        }
    }
}

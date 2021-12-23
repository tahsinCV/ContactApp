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
    public class UserInformationController : ControllerBase
    {
        private IUserInformationBL _userInformationBL;
        public UserInformationController(IUserInformationBL userInormationBL)
        {
            _userInformationBL = userInormationBL;
        }

        // GET: api/<UserInformationController>
        [HttpGet]
        public Result<List<UserInformationDO>> Get()
        {
            return _userInformationBL.GetAll();
        }

        // GET api/<UserInformationController>/5
        [HttpGet("{id}")]
        public Result<UserInformationDO> Get(int id)
        {
            return _userInformationBL.GetByID(id);
        }

        // POST api/<UserInformationController>
        [HttpPost]
        public Result<UserInformationDO> Add([FromBody] UserInformationDO model)
        {
            return _userInformationBL.Add(model);
        }

        // PUT api/<UserInformationController>/5
        [HttpPut("{id}")]
        public Result<UserInformationDO> Update(int id, [FromBody] UserInformationDO model)
        {
            return _userInformationBL.Update(model);
        }

        // DELETE api/<UserInformationController>/5
        [HttpDelete("{id}")]
        public Result<bool> Delete(int id)
        {
            return _userInformationBL.Delete(id);
        }
    }
}

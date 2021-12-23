using Microsoft.AspNetCore.Mvc;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Domain.Models;
using RT.Reports.ResultType;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportBL _reportBL;
        public ReportController(IReportBL ReportInormationBL)
        {
            _reportBL = ReportInormationBL;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public Result<List<ReportDO>> Get()
        {
            return _reportBL.GetAll();
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public Result<ReportDO> Get(int id)
        {
            return _reportBL.GetByID(id);
        }

        // POST api/<ReportController>
        [HttpPost]
        public Result<ReportDO> Add([FromBody] ReportDO model)
        {
            return _reportBL.Add(model);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public Result<ReportDO> Update(int id, [FromBody] ReportDO model)
        {
            return _reportBL.Update(model);
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public Result<bool> Delete(int id)
        {
            return _reportBL.Delete(id);
        }
    }
}

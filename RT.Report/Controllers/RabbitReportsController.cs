using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RT.Reports.Domain.Interfaces;
using RT.Reports.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RT.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitReportsController : ControllerBase
    {
        private IReportBL _reportBL;
        private IBus _bus;

        public RabbitReportsController(IReportBL reportBL,IBus bus)
        {
            _reportBL = reportBL;
            _bus = bus;
        }
      
        // POST api/<RabbitReportsController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReportRequestDO model)
        {
            if (model != null)
            {
                
                Uri uri = new Uri("rabbitmq://localhost/customQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(model);
                return Ok();
            }
            return BadRequest();

        }

    }
}

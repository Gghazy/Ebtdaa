using Ebtdaa.Application.SMSsGetWay.Dtos;
using Ebtdaa.Application.SMSsGetWay.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSGetWaysController : ControllerBase
    {
        private readonly ISMSService _SmsService;

        public SMSGetWaysController(ISMSService sMSService)
        {
            _SmsService = sMSService;
        }

        // GET: api/<SMSGetWaysController>
        [HttpGet]
        public async Task<IActionResult> GetAllSMS()
        {
            return Ok(_SmsService.GetSMSList());
        }

        // GET api/<SMSGetWaysController>/5
        [HttpGet("{id}")]
        public IActionResult CancelSMS(int Id)
        {
            return Ok(_SmsService.CancelSendSMS(Id));  
        }
        [HttpGet("CreateSMS")]
        public IActionResult CreateSMS(SMSGetWayRequestDto req) 
        {
            req.SendTime = "10:00 AM";
            return Ok(req);
            
        }
        // POST api/<SMSGetWaysController>
        [HttpPost]
        public IActionResult Post([FromBody] SMSGetWayRequestDto req)
        {
            return Ok(_SmsService.CreateSMS(req));
        }

    }
}

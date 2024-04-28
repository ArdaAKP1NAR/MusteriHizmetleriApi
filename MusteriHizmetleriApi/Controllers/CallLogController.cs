using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CallLogController : ControllerBase
    {
        private CallLogService callLogService;
        public CallLogController(CallLogService callLogService)
        {
            this.callLogService = callLogService;
        }
        [HttpPost]
        [Route("AddCallLog/customerServiceOfficeId = {customerServiceOfficeId}")]
        public async Task<IActionResult> AddCallLog(CallLogViewModel callLogViewModel, long customerServiceOfficeId)
        {
            var callLog = new CallLog()
            {
                CallLogDateTime = DateTime.Now,
                Complain = callLogViewModel.Complain,
                Notes = callLogViewModel.Notes,
                Solution = callLogViewModel.Solution,
            };
            await callLogService.AddCallLog(callLog, customerServiceOfficeId);
            return Ok("Callog has added successfully.");
        }
    }
}

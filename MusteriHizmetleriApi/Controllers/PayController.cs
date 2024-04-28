using CustomerServiceAPI.Service;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class PayController : ControllerBase
    {
        private PayHistoryService payHistoryService;
        public PayController(PayHistoryService payHistoryService)
        {
            this.payHistoryService = payHistoryService;
        }
        [HttpPost]
        [Route("payAllWorkersWage")]
        public async Task<IActionResult> PayAllWorkersWage()
        {
            await payHistoryService.PayAllWorkersWage();
            return Ok("All workers' wages have been paid.");
        }
    }
}

using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class WorkerController : ControllerBase
    {
        private WorkerService WorkerService;
        public WorkerController(WorkerService workerService)
        {
            WorkerService = workerService;
        }
        [HttpPost]
        [Route("AddWorker/customerServiceOfficeId = {customerServiceOfficeId}")]
        public async Task<IActionResult> AddWorker(WorkerViewModel workerViewModel, long customerServiceOfficeId)
        {
            var worker = new Worker()
            {
                Name = workerViewModel.Name,
                WeeklyWorkingHours = workerViewModel.WeeklyWorkingHours,
            };
            await WorkerService.AddWorker(worker, customerServiceOfficeId);
            return Ok("Worker has added successfully.");
        }
        [HttpPost]
        [Route("AddWage/workerId = {workerId}")]
        public async Task<IActionResult> AddWage(WageViewModel wageViewModel, long workerId)
        {
            var wage = new Wage()
            {
                HourlyPrice = wageViewModel.HourlyPrice,
            };
            await WorkerService.AddWage(wage, workerId);
            return Ok("Wage has added successfully.");
        }
        [HttpPost]
        [Route("AddWorkHistory/WorkerId = {WorkerId}")]
        public async Task<IActionResult> AddWorkHistory(WorkHistoryViewModel workHistoryViewModel, long WorkerId)
        {
            var workHistory = new WorkHistory()
            {
                HoursWorked = workHistoryViewModel.HoursWorked,
                WorkerId = WorkerId,
                WorkedDate = workHistoryViewModel.WorkedDate,
            };
            await WorkerService.AddWorkHistory(workHistory, WorkerId);
            return Ok("Work has History successfully added. ");
        }
    }
}

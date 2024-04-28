using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerServiceController : ControllerBase
    {
        private CustomerServiceOfficeService OfficeService;
        public CustomerServiceController(CustomerServiceOfficeService OfficeService)
        {
            this.OfficeService = OfficeService;
        }
        [HttpPost]
        [Route("AddCustomerServiceOffice/companyId = {companyId}")]
        public async Task<IActionResult> AddCustomerServiceOffice(CustomerServiceOfficeViewModel customerServiceOfficeViewModel, long companyId)
        {
            var CustomerService = new CustomerServiceOffice()
            {
                Name = customerServiceOfficeViewModel.Name,
                CompanyId = companyId
            };
            await OfficeService.AddCustomerServiceOffice(CustomerService, companyId);
            return Ok("Customer Service Office has added successfully.");
        }
    }
}

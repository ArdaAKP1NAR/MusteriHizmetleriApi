using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        private CustomerService customerService;
        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("AddCustomer/customerServiceOfficeId = {customerServiceOfficeId}")] // ayrı ayrı controller servisleri kendi conrolllerında çağır 
        public async Task<IActionResult> AddCustomer(CustomerViewModel customerViewModel, long customerServiceOfficeId)
        {
            var customer = new Customer()
            {
                Name = customerViewModel.Name,
                customerServiceOfficeId = customerServiceOfficeId
            };
            await customerService.AddCustomer(customer, customerServiceOfficeId);
            return Ok("Customer has added successfully. ");
        }
    }
}

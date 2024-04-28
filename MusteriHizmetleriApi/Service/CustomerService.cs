using CustomerServiceLibrary;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceAPI.Service
{
    public class CustomerService(CustomerRepository customerRepository,CustomerServiceRepository customerServiceRepository)
    {
        public async Task AddCustomer(Customer customer , long customerServiceOfficeId)
        {
            var newCustomer = await customerRepository.AddAsync(customer);
            var customerServiceOffice = await customerServiceRepository.GetAll().Where(a=>a.Id == customerServiceOfficeId).SingleAsync();

            customerServiceOffice.CustomerList.Add(newCustomer);
            await customerServiceRepository.UpdateAsync(customerServiceOffice);
        }
    }
}

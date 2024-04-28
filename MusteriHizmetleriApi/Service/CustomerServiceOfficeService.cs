using CustomerServiceLibrary;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceAPI.Service
{
    public class CustomerServiceOfficeService(CustomerServiceRepository customerServiceRepository,CompanyRepository companyRepository)
    {
        public async Task AddCustomerServiceOffice(CustomerServiceOffice customerServiceOffice,long companyId)
        {
            var newCustomerServiceOffice = await customerServiceRepository.AddAsync(customerServiceOffice);
            var Company = await companyRepository.GetAll().Where(a => a.Id == companyId).Include(a => a.Office).SingleAsync();

            Company.Office.Add(newCustomerServiceOffice);
            await companyRepository.UpdateAsync(Company);
        }
    }
}

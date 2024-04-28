using CustomerServiceLibrary;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;

namespace CustomerServiceAPI.Service
{
    public class CompanyService(CompanyRepository companyRepository)
    {
        public async Task AddCompany(Company company)
        {
            var newCompany = await companyRepository.AddAsync(company);
            await companyRepository.UpdateAsync(newCompany);
        }
    }
}

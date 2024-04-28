using System.Threading.Tasks;
using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private CompanyService companyService;
        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }
        [HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> AddCompany(CompanyViewModel companyViewModel)
        {
            var company = new Company()
            {
                Name = companyViewModel.Name
            };
            await companyService.AddCompany(company);

            return Ok("The company has successfully added.");
        }
    }
}

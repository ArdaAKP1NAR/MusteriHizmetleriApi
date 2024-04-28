using CustomerServiceAPI.Service;
using CustomerServiceLibrary.Repositories;

namespace CustomerServiceAPI
{
    public static class ProgramExtensions
    {
        public static void AddServices(this IServiceCollection Services)
        {
            Services.AddScoped<CustomerService>();
            Services.AddScoped<CallLogService>();
            Services.AddScoped<WorkerService>();
            Services.AddScoped<CustomerServiceOfficeService>();
            Services.AddScoped<CompanyService>();
            Services.AddScoped<PayHistoryService>();
          
            Services.AddScoped<CustomerRepository>();
            Services.AddScoped<CustomerServiceRepository>();
            Services.AddScoped<WorkerRepository>();
            Services.AddScoped<WageRepository>();
            Services.AddScoped<PayHistoryRepository>();
            Services.AddScoped<WorkHistoryRepository>();
            Services.AddScoped<CompanyRepository>();
            Services.AddScoped<CallLogRepository>();
        }
    }
}

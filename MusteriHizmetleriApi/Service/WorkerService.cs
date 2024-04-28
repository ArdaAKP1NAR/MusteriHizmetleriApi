using CustomerServiceLibrary;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceAPI.Service
{
    public class WorkerService(WorkerRepository workerRepository,CustomerServiceRepository customerServiceRepository,WageRepository wageRepository,WorkHistoryRepository workHistoryRepository) 
    {
        public async Task AddWorker(Worker worker, long customerServiceOfficeId) // Customer service e calisan baglama fonks
        {
            var newWorker = await workerRepository.AddAsync(worker);
            var customerService = await customerServiceRepository.GetAll().Where(a => a.Id == customerServiceOfficeId).Include(a => a.Workers).SingleAsync();
           
            customerService.Workers.Add(newWorker);
            await customerServiceRepository.UpdateAsync(customerService);
        }
        public async Task AddWage(Wage wage, long workerId)
        {
            var newWage = await wageRepository.AddAsync(wage);
            var worker = await workerRepository.GetAll().Where(a => a.Id == workerId).Include(a => a.Wage).SingleAsync();

            worker.Wage = newWage;
            await workerRepository.UpdateAsync(worker);
        }
        public async Task AddWorkHistory(WorkHistory workHistory, long workerId)
        {
            var newWorkHistory = await workHistoryRepository.AddAsync(workHistory);
            var worker = await workerRepository.GetAll().Where(a => a.Id == workerId).Include(a => a.WorkHistory).SingleAsync();
            if (workHistory != null)
            {
                worker.WorkHistory.Add(newWorkHistory);
                await workerRepository.UpdateAsync(worker);
            }
        }
    }
}

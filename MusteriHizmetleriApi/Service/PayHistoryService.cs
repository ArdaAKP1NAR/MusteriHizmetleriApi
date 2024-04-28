using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;
using CustomerServiceLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceAPI.Service
{
    public class PayHistoryService(PayHistoryRepository payHistoryRepository, WorkerRepository workerRepository)
    {
        public async Task PayWorkerWage()
        {
            //WorkHistory.Workdate > Payhistory.paymentdate olucak sonra cikan objelerin saatini sum edip saatlik ucretine carpicaksin
            var workhistories = await workerRepository.GetAll()
                .Include(a => a.WorkHistory)
                .Include(a => a.Wage).ToListAsync();
            foreach (var item in workhistories)
            {
                var payHistory = new PayHistory();
  
                var paymentHistory = await payHistoryRepository.GetAll().Where(a => a.WorkerId == item.Id).OrderBy(a=> a.Id).LastOrDefaultAsync();
                if (paymentHistory != null) {
                    var LatestWorks = item.WorkHistory.Where(a => a.WorkedDate > paymentHistory.PaymentDate).ToList();
                    var PriceToPay = (LatestWorks.Sum(a => a.HoursWorked) * item.Wage.HourlyPrice);
                    payHistory.WorkerId = item.Id;
                    payHistory.PaymentDate = DateTime.Now;
                    payHistory.AmountPaid = PriceToPay;
                    await payHistoryRepository.AddAsync(payHistory);
                }
                else
                {
                    var latestworks = item.WorkHistory.ToList();
                    var PriceToPay = (latestworks.Sum(a => a.HoursWorked) * item.Wage.HourlyPrice);
                    payHistory.WorkerId = item.Id;
                    payHistory.PaymentDate = DateTime.Now;
                    payHistory.AmountPaid = PriceToPay;
                    await payHistoryRepository.AddAsync(payHistory);
                }
            }


        }
        public async Task PayAllWorkersWage()
        {
            var workerIds = await workerRepository.GetAll().Select(w => w.Id).ToListAsync();

            foreach (var workerId in workerIds)
            {

                await PayWorkerWage();
            }
        }
    }
}

using CustomerServiceLibrary;
using CustomerServiceLibrary.Models;
using CustomerServiceLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceAPI.Service
{
    public class CallLogService(CallLogRepository callLogRepository,CustomerServiceRepository customerServiceRepository)
    {
        public async Task AddCallLog(CallLog callLog,long customerServiceOfficeId)
        {
            var newCallLog = await callLogRepository.AddAsync(callLog);
            var customerServiceOffice = await customerServiceRepository.GetAll().Where(a=>a.Id == customerServiceOfficeId).SingleAsync();

            customerServiceOffice.CallLog.Add(newCallLog);
            await customerServiceRepository.UpdateAsync(customerServiceOffice);
        }
    }
}

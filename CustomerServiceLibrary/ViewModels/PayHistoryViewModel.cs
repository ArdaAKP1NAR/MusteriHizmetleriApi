using CustomerServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.ViewModels
{
    public class PayHistoryViewModel
    {
        
        public int HoursWorked { get; set; }
        public int AmountPaid { get; set; } 
        public DateTime PaymentDate { get; set; }
    }
}

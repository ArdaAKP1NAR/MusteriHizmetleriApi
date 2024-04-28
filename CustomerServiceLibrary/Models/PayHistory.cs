using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class PayHistory : BaseEntity
    {
        public Worker Worker { get; set; }
        public long WorkerId { get; set; }
        public int HoursWorked { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

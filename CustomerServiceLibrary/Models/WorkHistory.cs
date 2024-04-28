using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class WorkHistory: BaseEntity
    {   
        public Worker Worker { get; set; }
        public long WorkerId { get; set; }
        public DateTime WorkedDate { get; set; } 
        public int HoursWorked { get; set; }
    }
}

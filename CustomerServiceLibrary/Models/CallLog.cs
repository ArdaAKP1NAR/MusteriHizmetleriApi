using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class CallLog : BaseEntity
    {

        public DateTime CallLogDateTime { get; set; }
        [MaxLength(255)]

        public string Complain {  get; set; }
        [MaxLength(255)]

        public string Solution { get; set; }
        [MaxLength(255)]

        public string Notes { get; set; }
    }
}

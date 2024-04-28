using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.ViewModels
{
    public class CallLogViewModel
    {
        public DateTime CallLogDateTime { get; set; }
        public string Complain { get; set; }
        public string Solution { get; set; }
        public string Notes { get; set; }
    }
}

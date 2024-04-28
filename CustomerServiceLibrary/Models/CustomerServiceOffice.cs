using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class CustomerServiceOffice : BaseEntity
    {
        [MaxLength(255)]        
        public string Name { get; set; }
        public Company Company { get; set; }
        public long CompanyId { get; set; }
        [JsonIgnore]
        public List<Customer> CustomerList { get; set; } //maybe jsonignore ı try 
        public List<Worker> Workers { get; set;}
        public List<CallLog> CallLog { get; set; }
    }
}

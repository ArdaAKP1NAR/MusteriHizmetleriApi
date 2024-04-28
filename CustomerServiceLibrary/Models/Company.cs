using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class Company : BaseEntity
    {

        [MaxLength(255)]
        public string Name { get; set; }
        [JsonIgnore]
        public List<CustomerServiceOffice> Office { get; set; }
    }
}

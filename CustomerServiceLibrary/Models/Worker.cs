using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Models
{
    public class Worker : BaseEntity
    {
        [MaxLength(255)]

        public string Name { get; set; }
        public int WeeklyWorkingHours { get; set; }

        [JsonIgnore]
        public List<WorkHistory>? WorkHistory { get; set;}
        public Wage? Wage { get; set; } // pay history yeni class o ay kac saat calistigi ne kadar odendigi ve tarih.
        public long? WageId { get; set; }
    }
}

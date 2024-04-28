using System.ComponentModel.DataAnnotations;

namespace CustomerServiceLibrary.Models
{
    public class Customer : BaseEntity
    {
        [MaxLength(255)]

        public string Name { get; set; }
        public CustomerServiceOffice CustomerServiceOffice { get; set; }
        public long customerServiceOfficeId { get; set; }
        
    }
}

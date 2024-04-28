using CustomerServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Repositories
{
    public class CompanyRepository(CustomerServiceContext context) : BaseRepository<Company>(context)
    {
    }
}

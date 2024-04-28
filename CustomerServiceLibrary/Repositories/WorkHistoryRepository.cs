using CustomerServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary.Repositories
{
    public class WorkHistoryRepository(CustomerServiceContext context) : BaseRepository<WorkHistory>(context)
    {
    }
}

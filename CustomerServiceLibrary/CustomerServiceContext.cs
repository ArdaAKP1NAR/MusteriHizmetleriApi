using CustomerServiceLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceLibrary
{
    public class CustomerServiceContext : DbContext
    {
        public CustomerServiceContext(DbContextOptions<CustomerServiceContext> options) : base(options)
        {

        }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CustomerServiceOffice> customerServiceOffices { get; set; }
        public DbSet<Wage> Wages { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<CallLog> CallLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PayHistory> PayHistory { get; set; }
        public DbSet<WorkHistory> WorkHistory { get; set; }
    }
}

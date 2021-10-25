using Microsoft.EntityFrameworkCore;
using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.DataAccess
{
    public class PaymentListDBContext : DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=PaymentsList";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}

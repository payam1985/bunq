using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MonetaryAccount> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Cart> Cards { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies()
        //        .UseSqlServer("Data Source=.;Initial Catalog=cms_eshop_core;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

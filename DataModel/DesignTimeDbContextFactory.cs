using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataModel
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private string _dbConnection = 
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bunq_db;Integrated Security=true";
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer(_dbConnection);
            var context = new ApplicationContext(builder.Options);
            return context;
        }
    }

}

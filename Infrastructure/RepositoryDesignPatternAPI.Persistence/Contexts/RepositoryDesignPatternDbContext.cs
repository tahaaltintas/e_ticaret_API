using Microsoft.EntityFrameworkCore;
using RepositoryDesignPatternAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Persistence.Contexts
{
    public class RepositoryDesignPatternDbContext : DbContext
    {
        public RepositoryDesignPatternDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

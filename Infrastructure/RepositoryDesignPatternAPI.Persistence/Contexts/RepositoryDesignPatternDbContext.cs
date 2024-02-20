using Microsoft.EntityFrameworkCore;
using RepositoryDesignPatternAPI.Domain.Entities;
using RepositoryDesignPatternAPI.Domain.Entities.Common;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                }; ;


            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
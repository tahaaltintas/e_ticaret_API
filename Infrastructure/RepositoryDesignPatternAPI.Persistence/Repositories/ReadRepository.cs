using Microsoft.EntityFrameworkCore;
using RepositoryDesignPatternAPI.Application.Repositories;
using RepositoryDesignPatternAPI.Domain.Entities.Common;
using RepositoryDesignPatternAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Persistence.Repositories
{
    public  class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly RepositoryDesignPatternDbContext _context;

        public ReadRepository(RepositoryDesignPatternDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


    }
}

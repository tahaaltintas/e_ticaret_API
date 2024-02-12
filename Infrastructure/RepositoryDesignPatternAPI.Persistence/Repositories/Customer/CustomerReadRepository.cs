using RepositoryDesignPatternAPI.Domain.Entities;
using RepositoryDesignPatternAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPatternAPI.Persistence.Contexts;

namespace RepositoryDesignPatternAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(RepositoryDesignPatternDbContext context) : base(context)
        {
        }
    }
}

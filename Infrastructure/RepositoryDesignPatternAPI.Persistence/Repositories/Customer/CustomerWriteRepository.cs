using RepositoryDesignPatternAPI.Application.Repositories;
using RepositoryDesignPatternAPI.Domain.Entities;
using RepositoryDesignPatternAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(RepositoryDesignPatternDbContext context) : base(context)
        {
        }
    }
}

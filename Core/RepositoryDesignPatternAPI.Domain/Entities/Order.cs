using RepositoryDesignPatternAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Descriptons { get; set; }
        public string Adress { get; set; }
        public Customer customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

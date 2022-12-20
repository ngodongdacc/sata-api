using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SatoDbContext _dbContext;

        public CustomerRepository(SatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetCustomer()
        {
            var data =  _dbContext.Customers.ToList();
            return data;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Context;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryEFMemory : ICutomerRepository
    {
        InMemoryContext _context;

        public CustomerRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            return customer;
        }

        public Customer Delete(int id)
        {
            var customer = Get(id);
            _context.Customers.Remove(customer);
            return customer;
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();  
        }
    }
}

using CustomerAppDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAppDAL.Repositories
{
    class CutomerRepositoryFakeDB : ICutomerRepository
    {
        private static int Id = 1;
        private static List<Customer> Customers = new List<Customer>();

        public Customer Create(Customer customer)
        {
            Customer newCustomer;
            Customers.Add(newCustomer = new Customer()
            {
                Id = Id++,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address
            });

            return newCustomer;
        }

        public Customer Delete(int id)
        {
            var custoemr = Get(Id);
            Customers.Remove(custoemr);
            return custoemr;
        }

        public Customer Get(int id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }
    }
}

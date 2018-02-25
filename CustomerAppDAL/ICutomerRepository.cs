using CustomerAppDAL.Entities;
using System.Collections.Generic;

namespace CustomerAppDAL
{
    public interface ICutomerRepository
    {
        Customer Create(Customer customer);

        List<Customer> GetAll();

        Customer Get(int id);

        Customer Delete(int id);
    }
}

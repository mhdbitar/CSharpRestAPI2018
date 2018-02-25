using CustomerAppBLL.BusinessObjects;
using System.Collections.Generic;

namespace CustomerAppBLL
{
    public interface ICustomerService
    {
        // Create new customer
        CustomerBO Create(CustomerBO customer);

        // Read all customers
        List<CustomerBO> GetAll();

        // Read a single customer
        CustomerBO Get(int Id);

        // Update an existing customer
        CustomerBO Update(CustomerBO customer);

        // Delete an existing cutomer
        CustomerBO Delete(int Id);
    }
}

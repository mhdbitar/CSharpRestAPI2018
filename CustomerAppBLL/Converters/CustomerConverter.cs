using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    public class CustomerConverter
    {
        internal Customer Convert(CustomerBO customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                Address = customer.Address,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        internal CustomerBO Convert(Customer customer)
        {
            return new CustomerBO()
            {
                Id = customer.Id,
                Address = customer.Address,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}

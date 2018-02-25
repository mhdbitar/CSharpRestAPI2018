using System;
using System.Collections.Generic;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL;
using CustomerAppDAL.Entities;
using System.Linq;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    public class CustomerService : ICustomerService
    {
        CustomerConverter conv = new CustomerConverter();
        DALFacade _facade;

        public CustomerService(DALFacade facade)
        {
            _facade = facade;
        }

        public CustomerBO Create(CustomerBO customer)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newCustomer = uow.CutomerRepository.Create(conv.Convert(customer));
                uow.Complete();
                return conv.Convert(newCustomer);
            }
        }

        public CustomerBO Delete(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newCustomer = uow.CutomerRepository.Delete(id);
                uow.Complete();
                return conv.Convert(newCustomer);
            }
        }

        public CustomerBO Get(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return conv.Convert(uow.CutomerRepository.Get(id));
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.CutomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO customer)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var customerFromDB = uow.CutomerRepository.Get(customer.Id);
                if (customerFromDB == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                customerFromDB.FirstName = customer.FirstName;
                customerFromDB.LastName = customer.LastName;
                customerFromDB.Address = customer.Address;
                uow.Complete();
                return conv.Convert(customerFromDB);
            }
        }
    }
}

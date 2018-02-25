using CustomerAppDAL.Repositories;
using CustomerAppDAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public ICutomerRepository CutomerRepository
        {
            //get { return new CutomerRepositoryFakeDB(); }

            get
            {
                return new CustomerRepositoryEFMemory(
                    new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}

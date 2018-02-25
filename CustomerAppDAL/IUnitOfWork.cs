using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICutomerRepository CutomerRepository { get; }

        int Complete();
    }
}

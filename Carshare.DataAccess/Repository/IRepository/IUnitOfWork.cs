using System;
using System.Collections.Generic;
using System.Text;

namespace Carshare.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICarRepository Car { get; }
        IUserRepository User { get; }
        ISP_CALL SP_Call { get; }

        void Save();
    }
}

using Carshare.Data;
using Carshare.DataAccess.Repository.IRepository;
using Carshare.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carshare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Car = new CarRepository(_db);
            User = new UserRepository(_db);
            SP_Call = new SP_Call(_db);

        }

        public ISP_CALL SP_Call
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IUserRepository User
        {
            get;
            private set;
        }
        public ICategoryRepository Category
        {
            get;
            private set;
        }

        public ICarRepository Car
        {
            get;
            private set;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

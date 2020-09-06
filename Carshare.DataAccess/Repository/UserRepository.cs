using Carshare.Data;
using Carshare.DataAccess.Repository.IRepository;
using Carshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carshare.DataAccess.Repository
{
    class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}

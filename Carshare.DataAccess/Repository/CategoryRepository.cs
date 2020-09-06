using Carshare.Data;
using Carshare.DataAccess.Repository.IRepository;
using Carshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carshare.DataAccess.Repository
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objectFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objectFromDb != null)
            {
                objectFromDb.Name = category.Name;

                _db.SaveChanges();
            }
        }
    }
}

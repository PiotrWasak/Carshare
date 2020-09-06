using Carshare.Data;
using Carshare.DataAccess.Repository.IRepository;
using Carshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carshare.DataAccess.Repository
{
    class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Car car)
        {
            var objectFromDb = _db.Cars.FirstOrDefault(s => s.Id == car.Id);
            if (objectFromDb != null)
            {
                objectFromDb.Brand = car.Brand;
                objectFromDb.Model = car.Model;
                objectFromDb.Model = car.ImageUrl;
                objectFromDb.Price = car.Price;
                objectFromDb.Description = car.Description;
                objectFromDb.CategoryId = car.CategoryId;

                _db.SaveChanges();
            }
        }
    }
}

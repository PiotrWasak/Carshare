using Carshare.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carshare.DataAccess.Repository.IRepository
{
    public interface ICarRepository : IRepository<Car>
    {
        void Update(Car car);
    }
}

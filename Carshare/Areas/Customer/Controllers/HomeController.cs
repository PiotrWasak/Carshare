using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Carshare.Models;
using Carshare.Models.ViewModels;
using Carshare.DataAccess;
using Carshare.Data;
using Carshare.DataAccess.Repository;
using Carshare.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Carshare.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _uow;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IUnitOfWork uow)
        {
            _uow = uow;
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Car> carList = _uow.Car.GetAll(includeProperties: "Category");
            return View(carList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Carshare.Models.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
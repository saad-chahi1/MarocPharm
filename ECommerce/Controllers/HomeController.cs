using ECommerce.AppDbContext;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ECommerceDbContext _db;

        public HomeController(ECommerceDbContext db, ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.Products.Select(s => new Product
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Quantity = s.Quantity,
                Price = s.Price,
                Image = s.Image,
                CategoryID = s.CategoryID,
                Category = _db.Categories.Where(a => a.Id == s.CategoryID).FirstOrDefault(),
                CurrentID = s.CurrentID,
                Current = _db.Currents.Where(a => a.Id == s.CurrentID).FirstOrDefault()
            }).ToList();

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using ECommerce.AppDbContext;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ECommerceDbContext _db;

        public CurrencyController(ECommerceDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new CurrencyViewModel { Currencies = _db.Currents.ToList(), Currency = new Current() });
        }
        [HttpPost]
        public IActionResult Create(Current currency)
        {
            if (ModelState.IsValid)
            {
                _db.Add(currency);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}

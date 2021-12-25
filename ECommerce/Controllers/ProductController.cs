using AutoMapper;
using ECommerce.AppDbContext;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ECommerceDbContext _db;

        [BindProperty]
        public ProductViewModel ModelVM { get; set; }

        public ProductController(ECommerceDbContext db)
        {
            _db = db;
            ModelVM = new ProductViewModel()
            {
                Categories = _db.Categories.ToList(),
                Currencies = _db.Currents.ToList(),
                Product = new Models.Product()
            };
        }

        public IActionResult Index()
        {
            var model = _db.Products.Include(m => m.Category);
            return View(model.ToList());
        }

        public IActionResult Create()
        {
            return View(ModelVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Product(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Products.Add(ModelVM.Product);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

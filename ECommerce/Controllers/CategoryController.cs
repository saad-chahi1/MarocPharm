using AspNetCoreHero.ToastNotification.Abstractions;
using ECommerce.AppDbContext;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ECommerceDbContext _db;
        //for Toast Message
        private readonly INotyfService _notyfService;

        public CategoryController(ECommerceDbContext db, INotyfService notyfService)
        {
            _db = db;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View(new CategoryViewModel { Categories = _db.Categories.ToList(), Category = new Category() });
        }
        
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Add(category);
                _db.SaveChanges();
                _notyfService.Success("You have successfully added new Category.");
                return RedirectToAction(nameof(Index));
            }
            _notyfService.Error("Your request is not completed");
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            var categoryUpdated = _db.Categories.FirstOrDefault(c => c.Id == id);
            categoryUpdated.Name = name;
            if (ModelState.IsValid)
            {
                _db.Update(categoryUpdated);
                _db.SaveChanges();
                _notyfService.Success("You have successfully Updated your Category.");
                return RedirectToAction(nameof(Index));
            }
            _notyfService.Error("Your request is not completed");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            long idLong = (long)id;
            var category = _db.Categories.Find(idLong);
            if (category == null)
            {
                _notyfService.Error("Your request is not completed");
                return RedirectToAction(nameof(Index));
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            _notyfService.Success("You have successfully deleted your Category.");
            return RedirectToAction(nameof(Index));
        }


    }
}

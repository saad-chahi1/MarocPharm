using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ECommerce.AppDbContext;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ECommerceDbContext _db;
        [Obsolete]
        private readonly IHostingEnvironment _appEnvironment;
        private readonly INotyfService _notyfService;

        [Obsolete]
        public ProductController(ECommerceDbContext db, IHostingEnvironment appEnvironment, INotyfService notyfService)
        {
            _db = db;
            _appEnvironment = appEnvironment;
            _notyfService = notyfService;
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
        [HttpGet]
        public IActionResult Create()
        {
            CategoryDropDownList();
            CurrencyDropDownList();
            return View();
        }
        

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string UrlImage = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_appEnvironment.WebRootPath, "images");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                                UrlImage = fileName;
                            }

                        }
                    }
                }
                var data = new Product()
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Image = UrlImage,
                    Price = product.Price,
                    CategoryID = product.CategoryID,
                    CurrentID = product.CurrentID
                };
                _db.Products.Add(data);
                _db.SaveChanges();
                _notyfService.Success("You have successfully Added new Product.");
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            long idLong = (long)id;
            var product = _db.Products.Find(idLong);
            if (product == null)
            {
                _notyfService.Error("Your request is not completed");
                return RedirectToAction(nameof(Index));
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            _notyfService.Success("You have successfully deleted your Product.");
            return RedirectToAction(nameof(Index));
        }

        private void CategoryDropDownList(object categorySelect = null)
        {
            var rolesQuery = _db.Categories.ToList();
            ViewBag.Categories = new SelectList(rolesQuery, "Id", "Name", categorySelect);
        }
        private void CurrencyDropDownList(object currencySelect = null)
        {
            var rolesQuery = _db.Currents.ToList();
            ViewBag.Currents = new SelectList(rolesQuery, "Id", "Name", currencySelect);
        }
    }
}

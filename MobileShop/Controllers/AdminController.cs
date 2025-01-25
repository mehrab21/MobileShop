using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.Models.Entities;
namespace MobileShop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult DashAdmin()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateNewProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewProduct(Product viewModel)
        {
            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Categories = viewModel.Categories,
                Price = viewModel.Price
            };
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction("ProductList", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var product = await _db.Products.ToListAsync();

            return View(product);
        }
        public IActionResult Samsung()
        {
            var samsungProducts = _db.Products
                .Where(p => p.Categories == "Samsung") // Filter by brand
                .ToList();
            return View(samsungProducts);
        }
        public IActionResult Apple()
        {
            var appleProducts = _db.Products
                .Where(p => p.Categories == "Apple") // Filter by brand
                .ToList();
            return View(appleProducts);
        }

        public IActionResult Xiaomi()
        {
            var appleProducts = _db.Products
                .Where(p => p.Categories == "Xiaomi") // Filter by brand
                .ToList();
            return View(appleProducts);
        }
    }
}

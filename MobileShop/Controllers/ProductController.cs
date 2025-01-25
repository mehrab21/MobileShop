using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data;

namespace MobileShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        //DI
        public ProductController(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var products = await _db.Products.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(products);
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _db.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Samsung()
        {
            var samsungProducts =  _db.Products
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

using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Controllers
{
    // [Authorize(Roles = "Farmer")]  // Disabled for testing
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // TEMP: Hardcoded FarmerId for testing
            int farmerId = 1;

            var products = _context.products
                                   .Where(p => p.FarmerId == farmerId)
                                   .ToList();

            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // TEMP: Hardcoded FarmerId for testing
            int farmerId = 1;

            product.FarmerId = farmerId;
            product.DateAdded = DateTime.Now;

            _context.products.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Controllers
{
    // [Authorize(Roles = "Employee")]  <-- remove or comment this if not needed
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the database context
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // The Index method that handles the products display and filtering
        public IActionResult Index(string category, DateTime? date)
        {
            // Start with all products in the database
            var products = _context.products.AsQueryable();

            // Filter by category if specified
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            // Filter by date if specified
            if (date.HasValue)
            {
                products = products.Where(p => p.DateAdded.Date == date.Value.Date);
            }

            // Convert to List and check if it's null or empty
            var productList = products.ToList();

            if (productList == null || !productList.Any())
            {
                // If there are no products, handle this by passing an empty list to the view
                return View(new List<Product>());
            }

            // Pass the filtered product list to the view
            return View(productList);
        }
    }
}

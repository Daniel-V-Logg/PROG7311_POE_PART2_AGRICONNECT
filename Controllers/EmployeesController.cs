using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriEnergyConnect.Controllers
{
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
            var products = _context.products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            if (date.HasValue)
            {
                products = products.Where(p => p.DateAdded.Date == date.Value.Date);
            }

            var productList = products.ToList();
            if (productList == null || !productList.Any())
            {
                return View(new List<Product>());
            }

            return View(productList);
        }

        // GET: Employees/AddFarmer
        public IActionResult AddFarmer(int? id)
        {
            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "Crop Farmer", Text = "Crop Farmer" },
                new SelectListItem { Value = "Livestock Farmer", Text = "Livestock Farmer" },
                new SelectListItem { Value = "Mixed Farmer", Text = "Mixed Farmer" }
            };

            // Create the farmer model to be used in the view
            Farmer farmer = new Farmer();

            if (id.HasValue)
            {
                var existingFarmer = _context.Farmers.Find(id.Value);
                if (existingFarmer != null)
                {
                    farmer = existingFarmer; // If editing, load the existing farmer data
                }
            }

            var allFarmers = _context.Farmers.ToList(); // Get all farmers to show in the list

            return View(new AddFarmerViewModel { Farmer = farmer, AllFarmers = allFarmers });
        }

        // POST: Employees/AddFarmer
        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                if (farmer.FarmerId == 0)
                {
                    _context.Farmers.Add(farmer); // Adding a new farmer
                }
                else
                {
                    _context.Farmers.Update(farmer); // Updating an existing farmer
                }
                _context.SaveChanges();
                return RedirectToAction("AddFarmer");
            }

            ViewBag.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "Crop Farmer", Text = "Crop Farmer" },
                new SelectListItem { Value = "Livestock Farmer", Text = "Livestock Farmer" },
                new SelectListItem { Value = "Mixed Farmer", Text = "Mixed Farmer" }
            };

            var allFarmers = _context.Farmers.ToList(); // Get all farmers to show in the list
            return View(new AddFarmerViewModel { Farmer = farmer, AllFarmers = allFarmers });
        }

        // GET: Employees/DeleteFarmer/5
        public IActionResult DeleteFarmer(int id)
        {
            var farmer = _context.Farmers.Find(id);
            if (farmer == null) return NotFound();

            _context.Farmers.Remove(farmer);
            _context.SaveChanges();
            return RedirectToAction("AddFarmer");
        }
    }
}

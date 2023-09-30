using Microsoft.AspNetCore.Mvc;
using OnlineShopNV.Data;
using OnlineShopNV.Models;

namespace OnlineShopNV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productTypes = _context.ProductTypes.ToList();
            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (productTypes == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.ProductTypes.Add(productTypes);
                await _context.SaveChangesAsync();
                TempData["save"] = "ProductType has been added successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType =  _context.ProductTypes.FirstOrDefault(x => x.Id == id);
            if (productType == null)
            {
                return BadRequest();
            }

            return  View(productType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (productTypes == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Update(productTypes);
                _context.ProductTypes.Update(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(productTypes);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _context.ProductTypes.FirstOrDefault(x => x.Id == id);
            if (productType == null)
            {
                return BadRequest();
            }

            return View(productType);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _context.ProductTypes.FirstOrDefault(x => x.Id == id);
            if (productType == null)
            {
                return BadRequest();
            }

            return View(productType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductTypes productTypes)
        {
            if (productTypes == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Update(productTypes);
                _context.ProductTypes.Remove(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(productTypes);
        }
    }
}

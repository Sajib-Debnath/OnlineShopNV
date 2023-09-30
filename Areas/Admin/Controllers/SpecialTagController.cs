using Microsoft.AspNetCore.Mvc;
using OnlineShopNV.Data;
using OnlineShopNV.Models;

namespace OnlineShopNV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _context;

        public SpecialTagController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var specialTags = _context.SpecialTags.ToList();
            return View(specialTags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (specialTags == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.SpecialTags.Add(specialTags);
                await _context.SaveChangesAsync();
                TempData["save"] = "ProductType has been added successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = _context.SpecialTags.FirstOrDefault(x => x.Id == id);
            if (specialTags == null)
            {
                return BadRequest();
            }

            return View(specialTags);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if (specialTags == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Update(productTypes);
                _context.SpecialTags.Update(specialTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(specialTags);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _context.SpecialTags.FirstOrDefault(x => x.Id == id);
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

            var specialTag = _context.SpecialTags.FirstOrDefault(x => x.Id == id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SpecialTags specialTag)
        {
            if (specialTag == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Update(productTypes);
                _context.Remove(specialTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(specialTag);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _db;
        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //Get create action method
        public IActionResult Create()
        {
            return View();
        }

        //Post create action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //Get Edit Action Method
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if(specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if(ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
            
        }

        //Get Details Action Mehtod
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if(specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }


        //Get Delete Action Mehtod
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if(specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTags specialTags)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(id != specialTags.Id)
            {
                return NotFound();
            }
            var specialTag = _db.SpecialTags.Find(id);
            if(specialTag == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Remove(specialTag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }
    }
}
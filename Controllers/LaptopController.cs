using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project5_6.Data;
using project5_6.Models;

namespace project5_6.Controllers
{
    public class LaptopController : Controller
    {
        private readonly WebContext _context;

        public LaptopController(WebContext context)
        {
            _context = context;
        }

        // GET: Laptop
        public async Task<IActionResult> Index()
        {
                        ViewBag.laptop = (from x in _context.Laptop
                               select x.brand).Distinct();
            return View(await _context.Laptop.ToListAsync());
        }

        // GET: Laptop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .SingleOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,date_added,image_id,category,brand,model_name,description,price,screen_size,panel_type,keyboard_layout,operating_system,processor,graphic_card,ram,main_storage,main_storage_type,extra_storage,webcam,hdmi,touchscreen,dvd_drive,staff_picked,recommended_purpose")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: Laptop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop.SingleOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // POST: Laptop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date_added,image_id,category,brand,model_name,description,price,screen_size,panel_type,keyboard_layout,operating_system,processor,graphic_card,ram,main_storage,main_storage_type,extra_storage,webcam,hdmi,touchscreen,dvd_drive,staff_picked,recommended_purpose")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: Laptop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .SingleOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptop.SingleOrDefaultAsync(m => m.Id == id);
            _context.Laptop.Remove(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptop.Any(e => e.Id == id);
        }
    }
}

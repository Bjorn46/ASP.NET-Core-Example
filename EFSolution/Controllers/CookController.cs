using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSolution.Data;
using EFSolution.Models;

namespace EFSolution.Controllers
{
    public class CookController : Controller
    {
        private readonly FoodAppContext _context;

        public CookController(FoodAppContext context)
        {
            _context = context;
        }

        // GET: Cook
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cooks.ToListAsync());
        }

        // GET: Cook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks
                .FirstOrDefaultAsync(m => m.CookId == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // GET: Cook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CookId,Rating,CprNumber,PhoneNumber,Adress,Name")] Cook cook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cook);
        }

        // GET: Cook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks.FindAsync(id);
            if (cook == null)
            {
                return NotFound();
            }
            return View(cook);
        }

        // POST: Cook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CookId,Rating,CprNumber,PhoneNumber,Adress,Name")] Cook cook)
        {
            if (id != cook.CookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookExists(cook.CookId))
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
            return View(cook);
        }

        // GET: Cook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cook = await _context.Cooks
                .FirstOrDefaultAsync(m => m.CookId == id);
            if (cook == null)
            {
                return NotFound();
            }

            return View(cook);
        }

        // POST: Cook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cook = await _context.Cooks.FindAsync(id);
            if (cook != null)
            {
                _context.Cooks.Remove(cook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookExists(int id)
        {
            return _context.Cooks.Any(e => e.CookId == id);
        }
    }
}

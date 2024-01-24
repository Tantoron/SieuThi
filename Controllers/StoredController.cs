using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SieuThi.Models;
using SieuThi.Repository;

namespace SieuThi.Controllers
{
    public class StoredController : Controller
    {
        private readonly MartContext _context;

        public StoredController(MartContext context)
        {
            _context = context;
        }

        // GET: Stored
        public async Task<IActionResult> Index()
        {
            return View(await _context.Storeds.ToListAsync());
        }

        // GET: Stored/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stored = await _context.Storeds
                .FirstOrDefaultAsync(m => m.MaPhieuNhap == id);
            if (stored == null)
            {
                return NotFound();
            }

            return View(stored);
        }

        // GET: Stored/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stored/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhieuNhap,Tensp,SoLuong,GiaNhap")] Stored stored)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stored);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stored);
        }

        // GET: Stored/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stored = await _context.Storeds.FindAsync(id);
            if (stored == null)
            {
                return NotFound();
            }
            return View(stored);
        }

        // POST: Stored/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhieuNhap,Tensp,SoLuong,GiaNhap")] Stored stored)
        {
            if (id != stored.MaPhieuNhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stored);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoredExists(stored.MaPhieuNhap))
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
            return View(stored);
        }

        // GET: Stored/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stored = await _context.Storeds
                .FirstOrDefaultAsync(m => m.MaPhieuNhap == id);
            if (stored == null)
            {
                return NotFound();
            }

            return View(stored);
        }

        // POST: Stored/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stored = await _context.Storeds.FindAsync(id);
            _context.Storeds.Remove(stored);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoredExists(int id)
        {
            return _context.Storeds.Any(e => e.MaPhieuNhap == id);
        }
    }
}

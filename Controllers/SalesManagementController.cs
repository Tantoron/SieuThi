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
    public class SalesManagementController : Controller
    {
        private readonly MartContext _context;

        public SalesManagementController(MartContext context)
        {
            _context = context;
        }

        // GET: SalesManagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesManagements.ToListAsync());
        }

        // GET: SalesManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesManagement = await _context.SalesManagements
                .FirstOrDefaultAsync(m => m.Mahoadon == id);
            if (salesManagement == null)
            {
                return NotFound();
            }

            return View(salesManagement);
        }

        // GET: SalesManagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahoadon,Ngay,TriGia,Tensp,SoLuong")] SalesManagement salesManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesManagement);
        }

        // GET: SalesManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesManagement = await _context.SalesManagements.FindAsync(id);
            if (salesManagement == null)
            {
                return NotFound();
            }
            return View(salesManagement);
        }

        // POST: SalesManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahoadon,Ngay,TriGia,Tensp,SoLuong")] SalesManagement salesManagement)
        {
            if (id != salesManagement.Mahoadon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesManagementExists(salesManagement.Mahoadon))
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
            return View(salesManagement);
        }

        // GET: SalesManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesManagement = await _context.SalesManagements
                .FirstOrDefaultAsync(m => m.Mahoadon == id);
            if (salesManagement == null)
            {
                return NotFound();
            }

            return View(salesManagement);
        }

        // POST: SalesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesManagement = await _context.SalesManagements.FindAsync(id);
            _context.SalesManagements.Remove(salesManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesManagementExists(int id)
        {
            return _context.SalesManagements.Any(e => e.Mahoadon == id);
        }
    }
}

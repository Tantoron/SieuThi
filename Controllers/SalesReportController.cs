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
    public class SalesReportController : Controller
    {
        private readonly MartContext _context;

        public SalesReportController(MartContext context)
        {
            _context = context;
        }

        // GET: SalesReport
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesReports.ToListAsync());
        }

        // GET: SalesReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports
                .FirstOrDefaultAsync(m => m.MaBaoCao == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // GET: SalesReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBaoCao,Ngay,DoanhThu")] SalesReport salesReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesReport);
        }

        // GET: SalesReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports.FindAsync(id);
            if (salesReport == null)
            {
                return NotFound();
            }
            return View(salesReport);
        }

        // POST: SalesReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBaoCao,Ngay,DoanhThu")] SalesReport salesReport)
        {
            if (id != salesReport.MaBaoCao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesReportExists(salesReport.MaBaoCao))
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
            return View(salesReport);
        }

        // GET: SalesReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReport = await _context.SalesReports
                .FirstOrDefaultAsync(m => m.MaBaoCao == id);
            if (salesReport == null)
            {
                return NotFound();
            }

            return View(salesReport);
        }

        // POST: SalesReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesReport = await _context.SalesReports.FindAsync(id);
            _context.SalesReports.Remove(salesReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesReportExists(int id)
        {
            return _context.SalesReports.Any(e => e.MaBaoCao == id);
        }
    }
}

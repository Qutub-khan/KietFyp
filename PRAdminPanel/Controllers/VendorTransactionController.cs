using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRAdminPanel.Data;
using PRAdminPanel.Models;

namespace PRAdminPanel.Controllers
{
    public class VendorTransactionController : Controller
    {
        private readonly AuthDbContext _context;

        public VendorTransactionController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: VendorTransaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: VendorTransaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorTransactionModel = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (vendorTransactionModel == null)
            {
                return NotFound();
            }

            return View(vendorTransactionModel);
        }

        // GET: VendorTransaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorTransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorNumber,VendorName,VendorAddress,Amount,Date")] VendorTransactionModel vendorTransactionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorTransactionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorTransactionModel);
        }

        // GET: VendorTransaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorTransactionModel = await _context.Transactions.FindAsync(id);
            if (vendorTransactionModel == null)
            {
                return NotFound();
            }
            return View(vendorTransactionModel);
        }

        // POST: VendorTransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendorNumber,VendorName,VendorAddress,Amount,Date")] VendorTransactionModel vendorTransactionModel)
        {
            if (id != vendorTransactionModel.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorTransactionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorTransactionModelExists(vendorTransactionModel.TransactionId))
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
            return View(vendorTransactionModel);
        }

        // GET: VendorTransaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorTransactionModel = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (vendorTransactionModel == null)
            {
                return NotFound();
            }

            return View(vendorTransactionModel);
        }

        // POST: VendorTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendorTransactionModel = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(vendorTransactionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorTransactionModelExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class PhoneOrdersController : Controller
    {
        private readonly PhoneStoreContext _context;

        public PhoneOrdersController(PhoneStoreContext context)
        {
            _context = context;
        }

        // GET: PhoneOrders
        public async Task<IActionResult> Index()
        {
            var phoneStoreContext = _context.PhoneOrder.Include(p => p.Order).Include(p => p.Phone);
            return View(await phoneStoreContext.ToListAsync());
        }

        // GET: PhoneOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneOrder = await _context.PhoneOrder
                .Include(p => p.Order)
                .Include(p => p.Phone)
                .FirstOrDefaultAsync(m => m.PhoneId == id);
            if (phoneOrder == null)
            {
                return NotFound();
            }

            return View(phoneOrder);
        }

        // GET: PhoneOrders/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "Id");
            return View();
        }

        // POST: PhoneOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhoneId,OrderId")] PhoneOrder phoneOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", phoneOrder.OrderId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "Id", phoneOrder.PhoneId);
            return View(phoneOrder);
        }

        // GET: PhoneOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneOrder = await _context.PhoneOrder.FindAsync(id);
            if (phoneOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", phoneOrder.OrderId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "Id", phoneOrder.PhoneId);
            return View(phoneOrder);
        }

        // POST: PhoneOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhoneId,OrderId")] PhoneOrder phoneOrder)
        {
            if (id != phoneOrder.PhoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneOrderExists(phoneOrder.PhoneId))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", phoneOrder.OrderId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "Id", phoneOrder.PhoneId);
            return View(phoneOrder);
        }

        // GET: PhoneOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneOrder = await _context.PhoneOrder
                .Include(p => p.Order)
                .Include(p => p.Phone)
                .FirstOrDefaultAsync(m => m.PhoneId == id);
            if (phoneOrder == null)
            {
                return NotFound();
            }

            return View(phoneOrder);
        }

        // POST: PhoneOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneOrder = await _context.PhoneOrder.FindAsync(id);
            _context.PhoneOrder.Remove(phoneOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneOrderExists(int id)
        {
            return _context.PhoneOrder.Any(e => e.PhoneId == id);
        }
    }
}

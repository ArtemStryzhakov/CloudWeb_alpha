﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace CloudWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly db _context;

        public OrdersController(db context)
        {
            _context = context;
        }

        // GET: Orders
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index()
        {
            var db = _context.Order.Include(o => o.ProductName).Include(o => o.Team).Include(o => o.whoseOrder);
            return View(await db.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ProductName)
                .Include(o => o.Team)
                .Include(o => o.whoseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["productId"] = new SelectList(_context.Product, "Id", "productName");
            ViewData["teamId"] = new SelectList(_context.Team, "Id", "TeamName");
            ViewData["customerId"] = new SelectList(_context.Customer, "Id", "Surname");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,teamId,productId,customerId,deadLine")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productId"] = new SelectList(_context.Product, "Id", "productName", order.productId);
            ViewData["teamId"] = new SelectList(_context.Team, "Id", "TeamName", order.teamId);
            ViewData["customerId"] = new SelectList(_context.Customer, "Id", "Surname", order.customerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.Product, "Id", "productName", order.productId);
            ViewData["teamId"] = new SelectList(_context.Team, "Id", "TeamName", order.teamId);
            ViewData["customerId"] = new SelectList(_context.Customer, "Id", "Surname", order.customerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,teamId,productId,customerId,deadLine")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["productId"] = new SelectList(_context.Product, "Id", "productName", order.productId);
            ViewData["teamId"] = new SelectList(_context.Team, "Id", "TeamName", order.teamId);
            ViewData["customerId"] = new SelectList(_context.Customer, "Id", "Surname", order.customerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ProductName)
                .Include(o => o.Team)
                .Include(o => o.whoseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'db.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Order.Any(e => e.Id == id);
        }
    }
}

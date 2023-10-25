using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Data;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    public class PasswordsController : Controller
    {
        private readonly PasswordsContext _context;

        public PasswordsController(PasswordsContext context)
        {
            _context = context;
        }

        // GET: Passwords
        public async Task<IActionResult> Index()
        {
              return _context.Passwords != null ? 
                          View(await _context.Passwords.ToListAsync()) :
                          Problem("Entity set 'PasswordsContext.Passwords'  is null.");
        }

        // GET: Passwords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passwords == null)
            {
                return NotFound();
            }

            return View(passwords);
        }

        // GET: Passwords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passwords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Username,Password")] Passwords passwords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwords);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passwords);
        }

        // GET: Passwords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords.FindAsync(id);
            if (passwords == null)
            {
                return NotFound();
            }
            return View(passwords);
        }

        // POST: Passwords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Username,Password")] Passwords passwords)
        {
            if (id != passwords.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordsExists(passwords.Id))
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
            return View(passwords);
        }

        // GET: Passwords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passwords == null)
            {
                return NotFound();
            }

            return View(passwords);
        }

        // POST: Passwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passwords == null)
            {
                return Problem("Entity set 'PasswordsContext.Passwords'  is null.");
            }
            var passwords = await _context.Passwords.FindAsync(id);
            if (passwords != null)
            {
                _context.Passwords.Remove(passwords);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordsExists(int id)
        {
          return (_context.Passwords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

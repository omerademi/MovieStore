using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieSite.Data;
using MovieSite.Data.Entities;

namespace MovieSite.Controllers
{
    public class PersonRolesController : Controller
    {
        private readonly MovieDbContext _context;

        public PersonRolesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: PersonRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonRoles.ToListAsync());
        }

        // GET: PersonRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRole = await _context.PersonRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personRole == null)
            {
                return NotFound();
            }

            return View(personRole);
        }

        // GET: PersonRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PersonRole personRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personRole);
        }

        // GET: PersonRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRole = await _context.PersonRoles.FindAsync(id);
            if (personRole == null)
            {
                return NotFound();
            }
            return View(personRole);
        }

        // POST: PersonRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PersonRole personRole)
        {
            if (id != personRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonRoleExists(personRole.Id))
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
            return View(personRole);
        }

        // GET: PersonRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personRole = await _context.PersonRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personRole == null)
            {
                return NotFound();
            }

            return View(personRole);
        }

        // POST: PersonRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personRole = await _context.PersonRoles.FindAsync(id);
            _context.PersonRoles.Remove(personRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonRoleExists(int id)
        {
            return _context.PersonRoles.Any(e => e.Id == id);
        }
    }
}

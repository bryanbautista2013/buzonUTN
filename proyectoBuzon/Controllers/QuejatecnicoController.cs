using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoBuzon.Models;

namespace proyectoBuzon.Controllers
{
    public class QuejatecnicoController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public QuejatecnicoController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Quejatecnico
        public async Task<IActionResult> Index()
        {
            var proyectoBuzonContext = _context.Quejatecnico.Include(q => q.IdQNavigation).Include(q => q.IdTecnicoNavigation);
            return View(await proyectoBuzonContext.ToListAsync());
        }

        // GET: Quejatecnico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejatecnico = await _context.Quejatecnico
                .Include(q => q.IdQNavigation)
                .Include(q => q.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuejatecnico == id);
            if (quejatecnico == null)
            {
                return NotFound();
            }

            return View(quejatecnico);
        }

        // GET: Quejatecnico/Create
        public IActionResult Create()
        {
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ");
            ViewData["IdTecnico"] = new SelectList(_context.Tecnico_1, "IdTecnico", "ApellidosTecnico");
            return View();
        }

        // POST: Quejatecnico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuejatecnico,IdQ,IdTecnico,Fecha,Descripcion")] Quejatecnico quejatecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quejatecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", quejatecnico.IdQ);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnico_1, "IdTecnico", "ApellidosTecnico", quejatecnico.IdTecnico);
            return View(quejatecnico);
        }

        // GET: Quejatecnico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejatecnico = await _context.Quejatecnico.FindAsync(id);
            if (quejatecnico == null)
            {
                return NotFound();
            }
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", quejatecnico.IdQ);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnico_1, "IdTecnico", "ApellidosTecnico", quejatecnico.IdTecnico);
            return View(quejatecnico);
        }

        // POST: Quejatecnico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuejatecnico,IdQ,IdTecnico,Fecha,Descripcion")] Quejatecnico quejatecnico)
        {
            if (id != quejatecnico.IdQuejatecnico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quejatecnico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuejatecnicoExists(quejatecnico.IdQuejatecnico))
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
            ViewData["IdQ"] = new SelectList(_context.Quejas, "IdQ", "DescripcionQ", quejatecnico.IdQ);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnico_1, "IdTecnico", "ApellidosTecnico", quejatecnico.IdTecnico);
            return View(quejatecnico);
        }

        // GET: Quejatecnico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejatecnico = await _context.Quejatecnico
                .Include(q => q.IdQNavigation)
                .Include(q => q.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuejatecnico == id);
            if (quejatecnico == null)
            {
                return NotFound();
            }

            return View(quejatecnico);
        }

        // POST: Quejatecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quejatecnico = await _context.Quejatecnico.FindAsync(id);
            _context.Quejatecnico.Remove(quejatecnico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuejatecnicoExists(int id)
        {
            return _context.Quejatecnico.Any(e => e.IdQuejatecnico == id);
        }
    }
}

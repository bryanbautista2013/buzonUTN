﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoBuzon.Models;

namespace proyectoBuzon.Controllers
{
    public class EstadosController : Controller
    {
        private readonly proyectoBuzonContext _context;

        public EstadosController(proyectoBuzonContext context)
        {
            _context = context;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            var totalpendientes = _context.Quejas.Where(q => q.IdEstadoNavigation.NomEstado == "Pendiente").Count();
            var totalespera = _context.Quejas.Where(q => q.IdEstadoNavigation.NomEstado == "Espera").Count();
            var totalresueltas = _context.Quejas.Where(q => q.IdEstadoNavigation.NomEstado == "Resuelto").Count();
            var totalquejas = _context.Quejas.Count();

            //pasar datos calculados
            ViewData["totalquejas"] = totalquejas;

            ViewData["totalpen"] = totalpendientes;
            ViewData["totalespera"] = totalespera;
            ViewData["totalres"] = totalresueltas;
            return View(await _context.Estado.ToListAsync());
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: Estados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NomEstado")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NomEstado")] Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.IdEstado))
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
            return View(estado);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estado.FindAsync(id);
            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoExists(int id)
        {
            return _context.Estado.Any(e => e.IdEstado == id);
        }
    }
}

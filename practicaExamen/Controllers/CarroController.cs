using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicaExamen.Models;

namespace practicaExamen.Controllers
{
    public class CarroController : Controller
    {
        private readonly practicaExamenContext _context;

        public CarroController(practicaExamenContext context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            var practicaExamenContext = _context.Carro.Include(c => c.propietario);
            return View(await practicaExamenContext.ToListAsync());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .Include(c => c.propietario)
                .FirstOrDefaultAsync(m => m.placa == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carro/Create
        public IActionResult Create()
        {
            ViewData["propietarioIdentificacion"] = new SelectList(_context.Set<Propietario>(), "identificaion", "identificaion");
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("placa,cilindraje,modelo,propietarioIdentificacion")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["propietarioIdentificacion"] = new SelectList(_context.Set<Propietario>(), "identificaion", "identificaion", carro.propietarioIdentificacion);
            return View(carro);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["propietarioIdentificacion"] = new SelectList(_context.Set<Propietario>(), "identificaion", "identificaion", carro.propietarioIdentificacion);
            return View(carro);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("placa,cilindraje,modelo,propietarioIdentificacion")] Carro carro)
        {
            if (id != carro.placa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.placa))
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
            ViewData["propietarioIdentificacion"] = new SelectList(_context.Set<Propietario>(), "identificaion", "identificaion", carro.propietarioIdentificacion);
            return View(carro);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .Include(c => c.propietario)
                .FirstOrDefaultAsync(m => m.placa == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(string id)
        {
            return _context.Carro.Any(e => e.placa == id);
        }
    }
}

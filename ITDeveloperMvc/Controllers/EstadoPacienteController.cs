using ITDeveloperData.ORM;
using ITDeveloperDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.Controllers
{
    public class EstadoPacienteController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public EstadoPacienteController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        // GET: EstadoPaciente
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoPaciente.ToListAsync());
        }

        // GET: EstadoPaciente/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPaciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }

            return View(estadoPaciente);
        }

        // GET: EstadoPaciente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoPaciente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] EstadoPaciente estadoPaciente)
        {
            if (ModelState.IsValid)
            {
                estadoPaciente.Id = Guid.NewGuid();
                _context.Add(estadoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPaciente);
        }

        // GET: EstadoPaciente/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPaciente.FindAsync(id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }
            return View(estadoPaciente);
        }

        // POST: EstadoPaciente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Descricao,Id")] EstadoPaciente estadoPaciente)
        {
            if (id != estadoPaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPacienteExists(estadoPaciente.Id))
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
            return View(estadoPaciente);
        }

        // GET: EstadoPaciente/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPaciente = await _context.EstadoPaciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }

            return View(estadoPaciente);
        }

        // POST: EstadoPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estadoPaciente = await _context.EstadoPaciente.FindAsync(id);
            _context.EstadoPaciente.Remove(estadoPaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPacienteExists(Guid id)
        {
            return _context.EstadoPaciente.Any(e => e.Id == id);
        }
    }
}

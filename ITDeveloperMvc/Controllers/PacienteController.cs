using ITDeveloperData.ORM;
using ITDeveloperDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITDeveloperMvc.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public PacienteController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Paciente.Include(navigationPropertyPath: x => x.EstadoPaciente).AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.Include(x=> x.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            ViewBag.EstadoPaciente = new SelectList(_context.EstadoPaciente, "id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
               // paciente.Id = Guid.NewGuid();
                _context.Add(paciente);
                await _context.SaveChangesAsync();
              //  return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            ViewBag.EstadoPaciente = new SelectList(_context.EstadoPaciente, "id", "Descricao", paciente.EstadoPacienteID);

            return View(paciente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewBag.EstadoPaciente = new SelectList(_context.EstadoPaciente, "id", "Descricao", paciente.EstadoPacienteID);

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
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
            ViewBag.EstadoPaciente = new SelectList(_context.EstadoPaciente, "id", "Descricao", paciente.EstadoPacienteID);

            return View(paciente);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}

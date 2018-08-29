using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IncubadoraApp.Data;
using IncubadoraApp.Models;

namespace IncubadoraApp.Controllers
{
    public class IncubadorasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncubadorasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Incubadoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Incubadora.ToListAsync());
        }

        // GET: Incubadoras/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora
                .SingleOrDefaultAsync(m => m.Id == id);
            if (incubadora == null)
            {
                return NotFound();
            }

            return View(incubadora);
        }

        // GET: Incubadoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incubadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperatura,Umidade")] Incubadora incubadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incubadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incubadora);
        }

        // GET: Incubadoras/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora.SingleOrDefaultAsync(m => m.Id == id);
            if (incubadora == null)
            {
                return NotFound();
            }
            return View(incubadora);
        }

        // POST: Incubadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Temperatura,Umidade")] Incubadora incubadora)
        {
            if (id != incubadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incubadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncubadoraExists(incubadora.Id))
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
            return View(incubadora);
        }

        // GET: Incubadoras/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incubadora = await _context.Incubadora
                .SingleOrDefaultAsync(m => m.Id == id);
            if (incubadora == null)
            {
                return NotFound();
            }

            return View(incubadora);
        }

        // POST: Incubadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var incubadora = await _context.Incubadora.SingleOrDefaultAsync(m => m.Id == id);
            _context.Incubadora.Remove(incubadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncubadoraExists(string id)
        {
            return _context.Incubadora.Any(e => e.Id == id);
        }

       
       // Atualiza Temperatura e Umidade
        public async Task<JsonResult> GetAtualiza(string id){

                    
            var incubadora = await _context.Incubadora
                .SingleOrDefaultAsync(m => m.Id == id);


            return Json(incubadora);

        }
    }
}

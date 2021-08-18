using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotiUcse.Models;

namespace NotiUcse.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly MvcNoticiasContext _context;

        public NoticiasController(MvcNoticiasContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoticiaModel.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaModel = await _context.NoticiaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticiaModel == null)
            {
                return NotFound();
            }

            return View(noticiaModel);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,FechaPublicacion,Seccion,Cuerpo")] NoticiaModel noticiaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticiaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticiaModel);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaModel = await _context.NoticiaModel.FindAsync(id);
            if (noticiaModel == null)
            {
                return NotFound();
            }
            return View(noticiaModel);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,FechaPublicacion,Seccion,Cuerpo")] NoticiaModel noticiaModel)
        {
            if (id != noticiaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticiaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaModelExists(noticiaModel.Id))
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
            return View(noticiaModel);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaModel = await _context.NoticiaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticiaModel == null)
            {
                return NotFound();
            }

            return View(noticiaModel);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticiaModel = await _context.NoticiaModel.FindAsync(id);
            _context.NoticiaModel.Remove(noticiaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaModelExists(int id)
        {
            return _context.NoticiaModel.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caisse.Data;
using caisse.Models;

namespace caisse.Controllers
{
    public class CategorieModelsController : Controller
    {
        private readonly caisseContext _context;

        public CategorieModelsController(caisseContext context)
        {
            _context = context;
        }

        // GET: CategorieModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategorieModel.ToListAsync());
        }

        // GET: CategorieModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.CategorieModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieModel == null)
            {
                return NotFound();
            }

            return View(categorieModel);
        }

        // GET: CategorieModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategorieModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategorieModel categorieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorieModel);
        }

        // GET: CategorieModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.CategorieModel.FindAsync(id);
            if (categorieModel == null)
            {
                return NotFound();
            }
            return View(categorieModel);
        }

        // POST: CategorieModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategorieModel categorieModel)
        {
            if (id != categorieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieModelExists(categorieModel.Id))
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
            return View(categorieModel);
        }

        // GET: CategorieModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.CategorieModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieModel == null)
            {
                return NotFound();
            }

            return View(categorieModel);
        }

        // POST: CategorieModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieModel = await _context.CategorieModel.FindAsync(id);
            if (categorieModel != null)
            {
                _context.CategorieModel.Remove(categorieModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieModelExists(int id)
        {
            return _context.CategorieModel.Any(e => e.Id == id);
        }
    }
}

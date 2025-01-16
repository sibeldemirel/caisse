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
    public class ProduitModelsController : Controller
    {
        private readonly caisseContext _context;

        public ProduitModelsController(caisseContext context)
        {
            _context = context;
        }

        // GET: ProduitModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProduitModel.ToListAsync());
        }

        // GET: ProduitModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produitModel = await _context.ProduitModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitModel == null)
            {
                return NotFound();
            }

            return View(produitModel);
        }

        // GET: ProduitModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProduitModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,InStockQtte,Category,Image")] ProduitModel produitModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produitModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produitModel);
        }

        // GET: ProduitModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produitModel = await _context.ProduitModel.FindAsync(id);
            if (produitModel == null)
            {
                return NotFound();
            }
            return View(produitModel);
        }

        // POST: ProduitModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,InStockQtte,Category,Image")] ProduitModel produitModel)
        {
            if (id != produitModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produitModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitModelExists(produitModel.Id))
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
            return View(produitModel);
        }

        // GET: ProduitModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produitModel = await _context.ProduitModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitModel == null)
            {
                return NotFound();
            }

            return View(produitModel);
        }

        // POST: ProduitModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produitModel = await _context.ProduitModel.FindAsync(id);
            if (produitModel != null)
            {
                _context.ProduitModel.Remove(produitModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitModelExists(int id)
        {
            return _context.ProduitModel.Any(e => e.Id == id);
        }
    }
}

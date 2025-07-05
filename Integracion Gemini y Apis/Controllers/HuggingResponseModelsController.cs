using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integracion_Gemini_y_Apis.Models;

namespace Integracion_Gemini_y_Apis.Controllers
{
    public class HuggingResponseModelsController : Controller
    {
        private readonly HuggingsReponse_ContextoBaseDeDatos _context;

        public HuggingResponseModelsController(HuggingsReponse_ContextoBaseDeDatos context)
        {
            _context = context;
        }

        // GET: HuggingResponseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HuggingResponseModel.ToListAsync());
        }

        // GET: HuggingResponseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huggingResponseModel = await _context.HuggingResponseModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (huggingResponseModel == null)
            {
                return NotFound();
            }

            return View(huggingResponseModel);
        }

        // GET: HuggingResponseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HuggingResponseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,response")] HuggingResponseModel huggingResponseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huggingResponseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huggingResponseModel);
        }

        // GET: HuggingResponseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huggingResponseModel = await _context.HuggingResponseModel.FindAsync(id);
            if (huggingResponseModel == null)
            {
                return NotFound();
            }
            return View(huggingResponseModel);
        }

        // POST: HuggingResponseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,response")] HuggingResponseModel huggingResponseModel)
        {
            if (id != huggingResponseModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huggingResponseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuggingResponseModelExists(huggingResponseModel.id))
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
            return View(huggingResponseModel);
        }

        // GET: HuggingResponseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huggingResponseModel = await _context.HuggingResponseModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (huggingResponseModel == null)
            {
                return NotFound();
            }

            return View(huggingResponseModel);
        }

        // POST: HuggingResponseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huggingResponseModel = await _context.HuggingResponseModel.FindAsync(id);
            if (huggingResponseModel != null)
            {
                _context.HuggingResponseModel.Remove(huggingResponseModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuggingResponseModelExists(int id)
        {
            return _context.HuggingResponseModel.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIUN_dotnet_mvc_statuspage.Models;

namespace DIUN_dotnet_mvc_statuspage.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcDiunUpdateContext _context;

        public HomeController(MvcDiunUpdateContext context)
        {
            _context = context;
        }

        // GET: Api
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiunUpdateModel.ToListAsync());
        }

        // GET: Api/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diunUpdateModel = await _context.DiunUpdateModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diunUpdateModel == null)
            {
                return NotFound();
            }

            return View(diunUpdateModel);
        }

        // GET: Api/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Api/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,diun_version,hostname,status,provider,image,hub_link,mime_type,digest,created,platform")] DiunUpdateModel diunUpdateModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diunUpdateModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diunUpdateModel);
        }


        // POST: Api/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,diun_version,hostname,status,provider,image,hub_link,mime_type,digest,created,platform")] DiunUpdateModel diunUpdateModel)
        {
            if (id != diunUpdateModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diunUpdateModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiunUpdateModelExists(diunUpdateModel.Id))
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
            return View(diunUpdateModel);
        }

        // GET: Api/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diunUpdateModel = await _context.DiunUpdateModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diunUpdateModel == null)
            {
                return NotFound();
            }

            return View(diunUpdateModel);
        }

        // POST: Api/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diunUpdateModel = await _context.DiunUpdateModel.FindAsync(id);
            _context.DiunUpdateModel.Remove(diunUpdateModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiunUpdateModelExists(string id)
        {
            return _context.DiunUpdateModel.Any(e => e.Id == id);
        }
    }
}

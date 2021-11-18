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
    public class ApiController : Controller
    {
        private readonly MvcDiunUpdateContext _context;

        public ApiController(MvcDiunUpdateContext context)
        {
            _context = context;
        }

        // GET: Api
        public async Task<IActionResult> Index()
        {
            var array = await _context.DiunUpdateModel.ToArrayAsync();

            if (array == null)
            {
                return NotFound();
            }

            return Ok(array);
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

            return Ok(diunUpdateModel);
        }

        // GET: Api/Create
        public IActionResult Create()
        {
            return Problem("GET Create request is not supported (try POST Create)");
        }

        // POST: Api/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //TODO look into changing this to a simple token / password system for API
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

        // GET: Api/Edit/5
        public async Task<IActionResult> Edit(string id = null)
        {
            return Problem("Editing existing data is not supported; this API supports Create, Read, or Delete only.");
        }

        // POST: Api/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,diun_version,hostname,status,provider,image,hub_link,mime_type,digest,created,platform")] DiunUpdateModel diunUpdateModel)
        {
            return Problem("Editing existing data is not supported; this API supports Create, Read, or Delete only.");
        }

        // GET: Api/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return Problem("GET Delete request is not supported (try POST Delete <id>)");
        }

        // POST: Api/Delete/5 -- note that API deletes might not be a desired use case for this app but who knows.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diunUpdateModel = await _context.DiunUpdateModel.FindAsync(id);
            _context.DiunUpdateModel.Remove(diunUpdateModel);
            await _context.SaveChangesAsync();
            return Ok(String.Format("Item with Id '{0}' was marked for deletion.", id));
        }

        private bool DiunUpdateModelExists(string id)
        {
            return _context.DiunUpdateModel.Any(e => e.Id == id);
        }
    }
}

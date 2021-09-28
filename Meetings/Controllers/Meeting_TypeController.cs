using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meetings.Data;
using Meetings.Models;

namespace Meetings.Controllers
{
    public class Meeting_TypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Meeting_TypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meeting_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meeting_Types.ToListAsync());
        }

        // GET: Meeting_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Type = await _context.Meeting_Types
                .FirstOrDefaultAsync(m => m.Meeting_Type_Id == id);
            if (meeting_Type == null)
            {
                return NotFound();
            }

            return View(meeting_Type);
        }

        // GET: Meeting_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meeting_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Meeting_Type_Id,Name")] Meeting_Type meeting_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting_Type);
        }

        // GET: Meeting_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Type = await _context.Meeting_Types.FindAsync(id);
            if (meeting_Type == null)
            {
                return NotFound();
            }
            return View(meeting_Type);
        }

        // POST: Meeting_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Meeting_Type_Id,Name")] Meeting_Type meeting_Type)
        {
            if (id != meeting_Type.Meeting_Type_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Meeting_TypeExists(meeting_Type.Meeting_Type_Id))
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
            return View(meeting_Type);
        }

        // GET: Meeting_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Type = await _context.Meeting_Types
                .FirstOrDefaultAsync(m => m.Meeting_Type_Id == id);
            if (meeting_Type == null)
            {
                return NotFound();
            }

            return View(meeting_Type);
        }

        // POST: Meeting_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting_Type = await _context.Meeting_Types.FindAsync(id);
            _context.Meeting_Types.Remove(meeting_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Meeting_TypeExists(int id)
        {
            return _context.Meeting_Types.Any(e => e.Meeting_Type_Id == id);
        }
    }
}

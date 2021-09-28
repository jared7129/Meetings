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
    public class Meeting_ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Meeting_ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meeting_Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meeting_Items.ToListAsync());
        }

        // GET: Meeting_Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Item = await _context.Meeting_Items
                .FirstOrDefaultAsync(m => m.Item_Id == id);
            if (meeting_Item == null)
            {
                return NotFound();
            }

            return View(meeting_Item);
        }

        // GET: Meeting_Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meeting_Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Item_Id,Item_Description,Comment,Due_Date,Status,Person_Responsible")] Meeting_Item meeting_Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting_Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting_Item);
        }

        // GET: Meeting_Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Item = await _context.Meeting_Items.FindAsync(id);
            if (meeting_Item == null)
            {
                return NotFound();
            }
            return View(meeting_Item);
        }

        // POST: Meeting_Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Item_Id,Item_Description,Comment,Due_Date,Status,Person_Responsible")] Meeting_Item meeting_Item)
        {
            if (id != meeting_Item.Item_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting_Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Meeting_ItemExists(meeting_Item.Item_Id))
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
            return View(meeting_Item);
        }

        // GET: Meeting_Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting_Item = await _context.Meeting_Items
                .FirstOrDefaultAsync(m => m.Item_Id == id);
            if (meeting_Item == null)
            {
                return NotFound();
            }

            return View(meeting_Item);
        }

        // POST: Meeting_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting_Item = await _context.Meeting_Items.FindAsync(id);
            _context.Meeting_Items.Remove(meeting_Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Meeting_ItemExists(int id)
        {
            return _context.Meeting_Items.Any(e => e.Item_Id == id);
        }
    }
}

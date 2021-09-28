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
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meetings.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.Meeting_Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMeetingItem([Bind("Items")] Meeting meeting)
        {
            meeting.Items.Add(new Meeting_Item());
            return PartialView("Meeting_Items", meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            var model = new Meeting();
            model.Items.Add(new Meeting_Item());
            PopulateDepartmentsDropDownList();
            return View(model);
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Meeting_Id,Meeting_Type,Meeting_Date,Minutes,Items")] Meeting meeting)
        {
            PopulateDepartmentsDropDownList();
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.Include(x => x.Items).FirstOrDefaultAsync(m => m.Meeting_Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        public async Task<ActionResult> GetMeetingDetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.Include(x => x.Items).FirstOrDefaultAsync(m => m.Meeting_Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return Json(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Meeting_Id,Meeting_Type,Meeting_Date,Minutes")] Meeting meeting)
        {
            PopulateDepartmentsDropDownList();
            if (id != meeting.Meeting_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var meetingToUpdate = await _context.Meetings.Include(x => x.Items).FirstOrDefaultAsync(m => m.Meeting_Id == id);
                    meetingToUpdate.Items = meeting.Items?.ToList();
                    meetingToUpdate.Meeting_Type = meeting.Meeting_Type;
                    meetingToUpdate.Meeting_Date = meeting.Meeting_Date;
                    meetingToUpdate.Minutes = meeting.Minutes;
                    _context.Meetings.Update(meetingToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Meeting_Id))
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
            return View(meeting);
        }



        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {

            var TypeQuery = from d in _context.Meeting_Types
                                orderby d.Name
                                select d;

            ViewBag.type = new SelectList(TypeQuery.AsNoTracking(), "Name", "Name", selectedDepartment);

        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.Meeting_Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.Meeting_Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warhammer40KFanSite;
using Warhammer40KFanSite.Models;


namespace Warhammer40KFanSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoryAdmin : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoryAdmin(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StoryAdmin
        public async Task<IActionResult> Index()
        {
              return _context.Stories != null ? 
                          View(await _context.Stories.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Stories'  is null.");
        }

        // GET: StoryAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stories == null)
            {
                return NotFound();
            }

            var story = await _context.Stories
                .FirstOrDefaultAsync(m => m.StoryID == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // GET: StoryAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoryAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoryID,StoryTitle,StoryTopic,StoryText,StoryDate")] Story story)
        {
            if (ModelState.IsValid)
            {
                _context.Add(story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET: StoryAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stories == null)
            {
                return NotFound();
            }

            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        // POST: StoryAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoryID,StoryTitle,StoryTopic,StoryText,StoryDate")] Story story)
        {
            if (id != story.StoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryExists(story.StoryID))
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
            return View(story);
        }

        // GET: StoryAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stories == null)
            {
                return NotFound();
            }

            var story = await _context.Stories
                .FirstOrDefaultAsync(m => m.StoryID == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: StoryAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stories'  is null.");
            }
            var story = await _context.Stories.FindAsync(id);
            if (story != null)
            {
                _context.Stories.Remove(story);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryExists(int id)
        {
          return (_context.Stories?.Any(e => e.StoryID == id)).GetValueOrDefault();
        }
    }
}

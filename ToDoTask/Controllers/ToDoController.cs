using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoTask;
using System.Text;
using System.Collections.Immutable;

namespace ToDoTask.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        // GET: ToDo
        public async Task<IActionResult> Index(string SearchString, string sortOrder)
        {
            ViewBag.StatusSortParam = sortOrder == "Completed" ? "Open" : "Completed" ?? "";
            ViewBag.DueDateSortParam = sortOrder == "DueDate"? "DueDateDesc" : "DueDate" ?? "";
            ViewBag.CategorySortParam = sortOrder == "Category"? "CategoryDesc" : "Category";
            ViewBag.PrioritySortParam = sortOrder == "Priority"? "PriorityDesc" : "Priority";
            
            var toDoContext = from t in _context.Tasks.Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status)
                              select t;
            //Search
            if(!String.IsNullOrEmpty(SearchString))
            {
                toDoContext = toDoContext.Where(s => s.Description.Contains(SearchString));
            }

            //Sorting Logic
            switch (sortOrder)

            {
                case "Completed":
                    toDoContext = toDoContext.OrderByDescending(t => t.StatusId);
                    break;
                case "Open":
                    toDoContext = toDoContext.OrderBy(t => t.StatusId);
                    break;
                case "Priority":
                    toDoContext = toDoContext.OrderBy(t => t.PriorityId);
                    break;
                case "PriorityDesc":
                    toDoContext = toDoContext.OrderByDescending(t => t.PriorityId);
                    break;
                case "DueDate":
                    toDoContext = toDoContext.OrderBy(t => t.DueDate);
                    break;
                case "DueDateDesc":
                    toDoContext = toDoContext.OrderByDescending(t => t.DueDate);
                    break;
                case "Category":
                    toDoContext = toDoContext.OrderBy(t => t.Category.CategoryId);
                    break;
                case "CategoryDesc":
                    toDoContext = toDoContext.OrderByDescending(t => t.Category.CategoryId);
                    break;
                default:
                    // toDoContext = toDoContext.OrderBy(t => t.StatusId);
                    toDoContext = toDoContext.OrderBy(t => t.DueDate);
                    break;
            }

            return View(await toDoContext.ToListAsync());
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(string SearchString, string sortOrder, int? id)
        {
            // ViewBag.StatusSortParam = String.IsNullOrEmpty(sortOrder) ? "Open" : "Completed";

            // var toDoContext = from t in _context.Tasks.Include(t => t.Category).Include(t => t.Priority).Include(t => t.Status)
            //                   select t;

            // //Search
            // if(!String.IsNullOrEmpty(SearchString))
            // {
            //     toDoContext = toDoContext.Where(s => s.Description.Contains(SearchString));
            // }

            // //Sorting Logic
            // switch (sortOrder)
            // {
            //     case "Open":
            //         toDoContext = toDoContext.OrderByDescending(t => t.StatusId);
            //         break;
            //     case "Completed":
            //         toDoContext = toDoContext.OrderByDescending(t => t.StatusId);
            //         break;
            //     default:
            //         toDoContext = toDoContext.OrderBy(t => t.DueDate);
            //         break;
            // }

            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,StatusId,PriorityId,DueDate,CategoryId")] TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", taskModel.CategoryId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", taskModel.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskModel.StatusId);
            return View(taskModel);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", taskModel.CategoryId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", taskModel.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskModel.StatusId);
            return View(taskModel);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,StatusId,PriorityId,DueDate,CategoryId")] TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskModel.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", taskModel.CategoryId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", taskModel.PriorityId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskModel.StatusId);
            return View(taskModel);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel != null)
            {
                _context.Tasks.Remove(taskModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}

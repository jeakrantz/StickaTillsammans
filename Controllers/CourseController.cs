using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StickaTillsammans.Data;
using StickaTillsammans.Models;

namespace StickaTillsammans.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string wwwRootPath;

        public CourseController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            wwwRootPath = hostEnvironment.WebRootPath;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }
        public async Task<IActionResult> CoursePublic()
        {
            var dataCourse = _context.Courses.Include(_ => _.Participants).ToListAsync();
            return View(await dataCourse);
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(_ => _.Participants).Where(m => m.Id == id).FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        // GET: Course/Details/5
        public async Task<IActionResult> DetailsPublic(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(_ => _.Participants).Where(m => m.Id == id).FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Time,Price,Spots,Description,ImageFile")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.ImageFile != null)
                {
                    //Skapa unikt namn
                    string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                    string extension = Path.GetExtension(course.ImageFile.FileName);

                    course.ImageName = fileName = fileName.Replace(" ", String.Empty) + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/images", fileName);

                    // Spara i filsystemet
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await course.ImageFile.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    course.ImageName = "placeholder.jpg";
                }

                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Time,Price,Spots,Description,ImageName,ImageFile")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (course.ImageFile != null)
                    {
                        course.ImageName = " ";

                        //Skapa unikt namn
                        string fileName = Path.GetFileNameWithoutExtension(course.ImageFile.FileName);
                        string extension = Path.GetExtension(course.ImageFile.FileName);

                        course.ImageName = fileName = fileName.Replace(" ", String.Empty) + DateTime.Now.ToString("yymmssfff") + extension;

                        string path = Path.Combine(wwwRootPath + "/images", fileName);

                        // Spara i filsystemet
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await course.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    else if (course.ImageName == null && course.ImageFile == null)
                    {
                        course.ImageName = "placeholder.jpg";
                    }
                    else
                    {
                        course.ImageName = course.ImageName;
                    }

                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}

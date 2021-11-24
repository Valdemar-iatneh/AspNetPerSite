using AspNetPerSite.Core;
using AspNetPerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetPerSite.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationContext db;
        public ProjectsController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Projects.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Project project)
        //{
        //    db.Projects.Add(project);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Index()
        //{
        //    var projects = ProjectStorage.Projects;
        //    return View(projects);
        //}
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            //ProjectStorage.Add(project);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string? name)
        {
            //ProjectStorage.RemoveByName(name);
            //db.Projects.RemoveByName(name);
            //await db.SaveChangesAsync();
            //return RedirectToAction("Index");
            if (name != null)
            {
                Project user = await db.Projects.FirstOrDefaultAsync(p => p.Name == name);
                if (user != null)
                {
                    db.Projects.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}

using CORE_MVC_Revision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CORE_MVC_Revision.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataBaseContext db;

        public StudentController(DataBaseContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            dynamic data = await db.Student.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                await db.Student.AddAsync(obj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public async Task<IActionResult> Details(int ID)
        {
            dynamic data = await db.Student.FirstOrDefaultAsync(x => x.id == ID);
            if (data == null)
                return NotFound();
            return View(data);
        }
        public async Task<IActionResult> Edit(int ID)
        {
            // dynamic data = await db.Student.FirstOrDefaultAsync(x => x.id == ID);
            var data = await db.Student.FindAsync(ID);//above line is also correct

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student obj)
        {

            // db.Student.Update(obj);
            db.Update(obj);//this line also work
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)//parametr name only id is workinng if i use idd or vallll then id recived null (i don't know why)
        {
            var data = await db.Student.FirstOrDefaultAsync(x=>x.id==id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirem(int id)
        {
            var data = await db.Student.FindAsync(id);
            if (data != null)
                db.Student.Remove(data);
            await db.SaveChangesAsync();
            //return RedirectToAction("Index", "Student"); //we use this line with controller name when we want to redirect another controller
            return RedirectToAction("Index");
        }
    }
}

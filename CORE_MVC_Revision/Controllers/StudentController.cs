using CORE_MVC_Revision.Models;
using Microsoft.AspNetCore.Mvc;

namespace CORE_MVC_Revision.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataBaseContext db;

        public StudentController(DataBaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           return View();
        }
       
       

    }
}

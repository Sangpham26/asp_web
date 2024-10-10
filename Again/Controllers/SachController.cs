using Again.Data;
using Microsoft.AspNetCore.Mvc;

namespace Again.Controllers
{
    public class SachController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SachController(ApplicationDbContext db)
        {
            _db = db; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

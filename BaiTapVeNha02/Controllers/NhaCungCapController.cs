using BaiTapVeNha02.Data;
using BaiTapVeNha02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;  // Thêm namespace này


namespace BaiTapVeNha02.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhaCungCapController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(NhaCungCap nhaCungCap, IFormFile file) 
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Lưu file vào đường dẫn trên server
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Lưu đường dẫn ảnh 
                nhaCungCap.ImageUrl = "/images/" + fileName;
            }
            _db.NhaCungCap.Add(nhaCungCap);  // db là context của database
            _db.SaveChanges();
            return View();
        }
    }
}

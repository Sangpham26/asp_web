using Again.Data;
using Again.Models;
using Microsoft.AspNetCore.Mvc;

namespace Again.Controllers
{
    public class TacGiaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TacGiaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tacgia = _db.TacGia.ToList();
            ViewBag.TacGia = tacgia;
            return View(tacgia);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TacGia author)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.TacGia.Add(author);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }

        [HttpPost]
        public IActionResult Edit(TacGia author)
        {
            if (ModelState.IsValid)
            {
                _db.TacGia.Update(author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var tacgia = _db.TacGia.Find(id);
            if (tacgia == null)
            {
                return NotFound();
            }
            _db.TacGia.Remove(tacgia);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

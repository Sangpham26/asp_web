using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_02.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _db.Books.Include("Author").ToList(); // Lấy danh sách sách cùng với thông tin tác giả
            return View(books);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            IEnumerable<SelectListItem> authorsList = _db.Authors.Select(
                item => new SelectListItem
                {
                    Value = item.AuthorId.ToString(),
                    Text = item.AuthorName
                }
            );
            ViewBag.AuthorsList = authorsList;

            Book book;

            if (id == 0)
            {
                book = new Book();
            }
            else
            {
                book = _db.Books.Include("Author").FirstOrDefault(b => b.BookId == id);
                if (book == null)
                {
                    return NotFound();
                }
            }

            return View(book);
        }


        [HttpPost]
        public IActionResult Upsert(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                {
                    _db.Books.Add(book);
                }
                else
                {
                    _db.Books.Update(book);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book); 
        }

    }
}

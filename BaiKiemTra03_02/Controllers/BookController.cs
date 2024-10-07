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
            // Lấy danh sách sách cùng với thông tin tác giả
            IEnumerable<Book> books = _db.Books.Include(b => b.Author).ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng Books
                _db.Books.Add(book);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
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

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin vào bảng Books
                _db.Books.Update(book);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
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

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
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

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Sử dụng LINQ để tìm kiếm
                var books = _db.Books.Where(b => b.Title.Contains(searchString)).ToList();
                ViewBag.SearchString = searchString;
                ViewBag.Books = books;
            }
            else
            {
                var books = _db.Books.ToList();
                ViewBag.Books = books;
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            // Tải danh sách tác giả từ cơ sở dữ liệu
            var authors = _db.Authors.Select(a => new SelectListItem
            {
                Value = a.AuthorId.ToString(),
                Text = a.AuthorName
            }).ToList();
            ViewBag.DSAuthor = authors; // Chuyển từ "Author" thành "DSAuthor"

            Book book;

            if (id == 0)
            {
                book = new Book(); // Khởi tạo Book mới nếu id bằng 0
            }
            else
            {
                book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id); // Lấy Book theo ID
                if (book == null)
                {
                    return NotFound(); // Nếu không tìm thấy Book
                }
            }

            return View(book); // Trả về view với đối tượng Book
        }

        [HttpPost]
        public IActionResult Upsert(Book book)
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của Model
            {
                if (book.BookId == 0)
                {
                    _db.Books.Add(book); // Thêm Book mới
                }
                else
                {
                    _db.Books.Update(book); // Cập nhật Book hiện tại
                }
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction("Index"); // Chuyển về Index
            }

            // Nếu có lỗi, tải lại danh sách tác giả để đảm bảo dropdown không bị rỗng
            var authors = _db.Authors.Select(a => new SelectListItem
            {
                Value = a.AuthorId.ToString(),
                Text = a.AuthorName
            }).ToList();
            ViewBag.DSAuthor = authors; // Đảm bảo DSAuthor có dữ liệu

            return View(book); // Trả về view với đối tượng Book
        }
    }
}

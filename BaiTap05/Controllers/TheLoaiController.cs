using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngay 6";
            ViewBag.Thang = "Thang 9";
            ViewData["nam"] = "Nam 2024";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                ID = 1,
                Name = "Trinh Tham"
            };

            return View(theloai);
        }
    }
}

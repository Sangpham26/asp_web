using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BaiTap02()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "VGA ASUS ROG Strix GeForce RTX 4090",
                GiaBan = 6000, 
                AnhMoTa = "/images/4090.jpg"
            };

            return View(sanpham);
        }
    }
}

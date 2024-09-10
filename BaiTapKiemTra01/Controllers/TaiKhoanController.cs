using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (model.TenTaiKhoan != null)
            {
                return Content(model.TenTaiKhoan);
            }
            return View(model);
        }
    }
}

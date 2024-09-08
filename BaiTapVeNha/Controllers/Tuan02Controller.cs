using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Pham Ngoc Sang";
            ViewBag.MSSV = "1822040884";
            ViewData["nam"] = "Nam 2024";
            return View();
        }
        //Tạo action MayTinh() có tham số a,b,pheptinh
        public IActionResult MayTinh(double a, double b, string pheptinh)
        {
            // Khai báo 2 biến là KetQua và errorMessage để báo lỗi 
            double ketQua = 0;
            string errorMessage = " ";

            // Thực hiện phép tính
            try
            {
                switch (pheptinh)
                {
                    case "cong":
                        ketQua = a + b;
                        break;
                    case "tru":
                        ketQua = a - b;
                        break;
                    case "nhan":
                        ketQua = a * b;
                        break;
                    case "chia":
                        if (b == 0)
                        {
                            errorMessage = "Không thể chia cho 0!";
                        }
                        else
                        {
                            ketQua = a / b;
                        }
                        break;
                    default:
                        errorMessage = "Phép tính không hợp lệ!";
                        break;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Có lỗi xảy ra: {ex.Message}";
            }

            // Lưu kết quả vào ViewBag
            if (errorMessage == null)
            {
                ViewBag.KetQua = ketQua;
            }
            else
            {
                ViewBag.KetQua = errorMessage;
            }

            // Trả kết quả về View
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}

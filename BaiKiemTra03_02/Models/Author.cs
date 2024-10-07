using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }  // Mã tác giả

        [Required(ErrorMessage = "Không được để trống Tên tác giả!")]
        [Display(Name = "Tên tác giả")]
        public string AuthorName { get; set; }  // Tên tác giả

        [Display(Name = "Quốc tịch")]
        public string? Nationality { get; set; }  // Quốc tịch (có thể để trống)

        [Display(Name = "Năm sinh")]
        public DateTime BirthYear { get; set; } = DateTime.Now;  // Ngày tạo
    }
}

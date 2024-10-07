using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }  

        [Required(ErrorMessage = "Không được để trống Tên tác giả!")]
        [Display(Name = "Tên tác giả")]
        public string AuthorName { get; set; }  

        [Required(ErrorMessage = "Không được để trống Quốc tịch!")]
        [Display(Name = "Quốc tịch")]
        public string? Nationality { get; set; } 

        [Display(Name = "Năm sinh")]
        public DateTime BirthYear { get; set; } = DateTime.Now;  
    }
}

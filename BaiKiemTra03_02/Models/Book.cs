using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Năm xuất bản không được để trống.")]
        public double PublicCationYear { get; set; }

        [Required(ErrorMessage = "Thể loại không được để trống.")]
        public string Genre { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Mã tác giả không được để trống.")]
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double PublicCationYear { get; set; }
        public string Genre { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}

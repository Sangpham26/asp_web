using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Again.Models
{
    public class Sach
    {
        [Key]
        public int SachID {  get; set; }
        [Required]
        public string SachName { get; set; }
        public double SachGia { get; set; }
        public string SachMota { get; set; }
        public string SachTheLoai { get; set; }
        public DateTime SachNSX { get; set; } = DateTime.Now;
        public string? SachImg { get; set; }

        //Khóa ngoại
        public int TacgiaID { get; set; }
        [ForeignKey("TacgiaID")]
        [ValidateNever]
        public TacGia TacGia { get; set; }

    }
}

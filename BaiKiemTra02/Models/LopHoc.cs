using System;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenLopHoc { get; set; }
        public DateTime NamNhapHoc { get; set; } = DateTime.Now;
        public DateTime NamRaTruong { get; set; } = DateTime.Now;
        public int SoLuongSinhVien { get; set; }
    }
}

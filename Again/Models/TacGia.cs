using System.ComponentModel.DataAnnotations;

namespace Again.Models
{
    public class TacGia
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TacgiaName { get; set; }
        public string TacgiaQuocTich {  get; set; }
        public DateTime TacgiaNgaySinh { get; set; } = DateTime.Now;

    }
}

using BaiTap07.Models;
using Microsoft.EntityFrameworkCore;
namespace BaiTap07.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<TheLoai> TheLoai { get; set; }

    }
}

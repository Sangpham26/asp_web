var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Trang_chu",
    pattern: "Trang_chu/{action=Index}/{id?}",  // Thay đổi dấu gạch nối ở đây
    defaults: new { controller = "Home" }
);
app.MapControllerRoute(
    name: "Dang_ky",
    pattern: "Dang_ky/{action=DangKy}/{id?}",  // Thay đổi dấu gạch nối ở đây
    defaults: new { controller = "TaiKhoan" }
);
app.MapControllerRoute(
    name: "BaiTap02",
    pattern: "BaiTap02/{action=BaiTap02}/{id?}",  // Thay đổi dấu gạch nối ở đây
    defaults: new { controller = "SanPham" }
);


app.Run();

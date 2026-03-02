using Auto.Market.Data;
using AutoMapper;
using Avto.Market.BLL.Interface;
using Avto.Market.BLL.Services;
using Avto.Market.BLL.Mapers;
using Avto.Market.DAL;
using Microsoft.EntityFrameworkCore;
using Auto.Market.Models; // Kategoriya modeli uchun

var builder = WebApplication.CreateBuilder(args);

// 1. Controller va View-larni qo'shish
builder.Services.AddControllersWithViews();

// 2. Database ulanishi
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("localhost")));

// 3. AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 4. Dependency Injection
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

// --- 🛑 AVTOMATIK KATEGORIYA YARATISH (XATONI YO'QOTISH UCHUN) ---
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Bazani tekshiramiz, agar Categories jadvali bo'sh bo'lsa bitta qator qo'shamiz
    if (!context.Categories.Any())
    {
        context.Categories.Add(new Category { Id = 1, Name = "Yengil avtomobil" });
        context.SaveChanges();
    }
}
// ----------------------------------------------------------------

// 5. Middleware sozlamalari
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
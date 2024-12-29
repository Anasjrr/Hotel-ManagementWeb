using Microsoft.EntityFrameworkCore;
using HotelReservationWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext with SQL Server
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use middleware in the correct order
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}"); 

// Configure default routing
app.MapDefaultControllerRoute();

app.Run();

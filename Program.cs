using TVBroadcastScheduler.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TVBroadcastScheduler.Data;

var builder = WebApplication.CreateBuilder(args);

//  Connect to SQL Server using EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Add MVC services and session
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Enable session support

var app = builder.Build();

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();    // To serve CSS/JS from wwwroot

app.UseRouting();
app.UseSession();        // Important: use session BEFORE authorization
app.UseAuthorization();

//  Default route goes to Account/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

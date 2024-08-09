using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Modules.Models;
var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DbContextClassConnection") ?? throw new InvalidOperationException("Connection string 'DbContextClassConnection' not found.");
builder.Services.AddDbContext<DbContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).
    AddDefaultTokenProviders()
.AddEntityFrameworkStores<DbContextClass>();
// adding services of razor pages 
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmailSender, EmailSender>();


// Add services to the container.
builder.Services.AddControllersWithViews();
//adding authorization services
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Web}/{action=Index}/{id?}");
//Middleware
app.MapRazorPages();
app.Run();

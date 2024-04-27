using Microsoft.EntityFrameworkCore;
using ModuloGerente___DAW.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Cuando lo use la dani xd
builder.Services.AddDbContext<dulcesaborDbContext>(opt =>
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("dulcesaborDbContext")
            )
);

//Cuando lo use la lalanis xd
//builder.Services.AddDbContext<dulcesaborDbContext>(opt =>
//        opt.UseSqlServer(
//            builder.Configuration.GetConnectionString("equiposDbConnection")
//            )
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

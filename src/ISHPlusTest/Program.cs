using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISHPlusTest.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ISHPlusTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ISHPlusTestContext") ?? throw new InvalidOperationException("Connection string 'ISHPlusTestContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DOCTORs}/{action=Index}/{id?}");

app.Run();

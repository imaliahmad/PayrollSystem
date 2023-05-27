using Microsoft.EntityFrameworkCore;
using PS.BLL;
using PS.DAL;
using PS.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region DALRegion
builder.Services.AddTransient<IDepartmentDb, DepartmentDb>();
builder.Services.AddTransient<IEmployeeDb, EmployeeDb>();
#endregion

#region BLLRegion
builder.Services.AddTransient<IDepartmentBs, DepartmentBs>();
builder.Services.AddTransient<IEmployeeBs, EmployeeBs>();
#endregion
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=PayrollSystemA;Trusted_Connection=True"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();


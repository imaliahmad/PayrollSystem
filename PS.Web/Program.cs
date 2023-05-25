var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region DALRegion
#endregion

#region BLLRegion
#endregion

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();


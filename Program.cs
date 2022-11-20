using BlazorNonConformity.Data.Context;
using BlazorNonConformity.Data.Interfaces;
using BlazorNonConformity.Data.Repository;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.


#region DI
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
#endregion

#region EF Core
string mySqlConnection = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContextPool<AppDBContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
#endregion


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
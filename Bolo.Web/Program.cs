using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Bolo.Application.Interfaces;
using Bolo.Infrastructure.Repositories;
using Bolo.Infrastructure.Auth.DbContext;
using System.Configuration;
using Bolo.Infrastructure.Auth.Services;
using Bolo.Infrastructure.Auth;
using Bolo.Infrastructure.Auth.DbContext;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddInfrastructureIdentity();
builder.Services.AddIdentityDbContext(builder.Configuration);
builder.Services.AddIdentityAuth();

builder.Services.AddInfrastructure(builder.Configuration); 

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

//app.MapAreaControllerRoute(
//        name: "Identity",
//        areaName: "Identity",
//        pattern: "Identity/{controller=Account}/{action=Login}"
//    );

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller}/{action}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

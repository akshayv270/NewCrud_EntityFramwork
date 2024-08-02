
//var builder = xWebApplication.CreateBuilder(args);
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationBussinessServices;
using WebApplicationDataEntity;
using WebApplicationRepository;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("Mydatabase");
builder.Services.AddDbContext<Employee_ManagmentContext>(options => options.UseSqlServer(connectionString));
RepositoryDepedencyContainer.Registration(builder.Services);
ServiceDepedencyContainer.Registration(builder.Services);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

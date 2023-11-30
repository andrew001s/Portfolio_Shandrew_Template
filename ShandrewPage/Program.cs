using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ShandrewPage.Conections;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


IConfiguration configuration = builder.Configuration;
builder.Services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MongoDBConnection")));
builder.Services.AddScoped<DBMongo>();
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

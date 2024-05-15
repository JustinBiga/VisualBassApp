using MySql.Data.MySqlClient;
using System.Data;
using VisualBaseApp.Models;
using VisualBaseApp;

var builder = WebApplication.CreateBuilder(args);
MySqlConnection connection = new();
try
{
    connection.Open();
    // Connection established, you can now execute SQL queries
}
catch (MySqlException)
{
    // Handle any exceptions
}
finally
{
    connection.Close(); // Make sure to close the connection when done
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped((s) =>
{
    IDbConnection connection = new MySqlConnection(builder.Configuration.GetConnectionString("VisualBaseApp"));
    connection.Open();
    return connection;
});



builder.Services.AddTransient<IPhotoRepository, PhotoRepository>();
WebApplication app = builder.Build();

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



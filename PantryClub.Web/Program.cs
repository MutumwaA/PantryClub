using PantryClub.Web;
using PantryClub.Web.Services;
using PantryClub.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();

SD.UserAPIBase = configuration["ServiceUrls:UserAPIBase"];
SD.OrderAPIBase = configuration["ServiceUrls:OrderAPIBase"];

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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
    name: "userDetails",
    pattern: "/User/UserDetails/{userId}",
    defaults: new { controller = "User", action = "UserDetails" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=UserIndex}/{id?}"
);

app.Run();

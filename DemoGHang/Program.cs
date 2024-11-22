using DemoGHang.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GHDbContex>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(30);
    //thi?t l?p cho qu� tr�nh sessionn l� 15s, k?t th�c h�nh ??ng sau 16s
    //sesion s? t? ng?t sau 15s, trong 15s m� tieesp t?c 1 hhafnhh ??ng kh�c th� sessionn s? reset th?i gian v? 0
});
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
app.UseSession(); // kh?i tajo s? d?ng session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.AspNetCore.Identity;
using ShopPanel.DataAccess.Context;
using ShopPanel.Entity.Entities;
using ShopPanel.DataAccess.Extensions;
using ShopPanel.Business.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
builder.Services.AddSession();

//var assembly = Assembly.GetExecutingAssembly();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})

    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "FoodBox",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict, //���nc� taraf isteklerden kaynaklanan hi�bir iste�e SameSite olarak set edilen Cookie g�nderilmeyecektir.
        SecurePolicy = CookieSecurePolicy.SameAsRequest //Canl�ya c�karken SameAsRequest yerine Always se�ene�i se�ilir.
                                                        //Sadece htpps �erezlerin g�venli bir �znitelikle ayarlanmas�na izin verir ve g�venli olmayan
                                                        //�erezlerin ayarlanmas�n� engeller 
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7); //7 g�n boyunca gri� bilgiileri tutulur
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");//Yetkisiz giri� oldu�unda hata verir
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
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
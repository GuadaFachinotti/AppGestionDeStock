using Gestion.Core.Business;
using Gestion.Core.Configuration;
using Gestion.Core.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Configurar autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyCookieAuth";
        options.LoginPath = "/Account/Login";
    });
// se está configurando un servicio en una aplicación ASP.NET Core.
var config = new Gestion.Core.Configuration.Config()
{
    ConnectionString = builder.Configuration.GetConnectionString("GestionConnectionString")
};

builder.Services.AddScoped<Config>(p => {
    return config;
});

//se está registrando dos servicios en el contenedor de inyección de dependencias
//de una aplicación ASP.NET Core.

builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<OperacionesRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ProductoBusiness>();
builder.Services.AddScoped<OperacionesBusiness>();
builder.Services.AddScoped<UsuarioBusiness>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication(); //Añadir autenticación al pipeline
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

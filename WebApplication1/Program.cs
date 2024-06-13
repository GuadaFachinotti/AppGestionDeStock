using Gestion.Core.Business;
using Gestion.Core.Configuration;
using Gestion.Core.Data;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<ProductoBusiness>();
builder.Services.AddScoped<OperacionesBusiness>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

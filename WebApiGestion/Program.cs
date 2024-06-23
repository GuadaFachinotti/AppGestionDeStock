using Gestion.Core.Business;
using Gestion.Core.Configuration;
using Gestion.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
builder.Services.AddScoped<UsuarioBusiness>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using InventariosCore.Controllers;
using InventariosCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexi�n est�tica para PostgreSQLDataAccess
PostgreSQLDataAccess.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar controlador ProductosController para inyecci�n de dependencias
builder.Services.AddScoped<ProductosController>();

// Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Configurar puerto din�mico para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();

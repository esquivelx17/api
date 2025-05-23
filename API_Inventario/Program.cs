using InventariosCore.Controllers;   // Asegúrate que el namespace coincide con tu proyecto
using InventariosCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión estática para PostgreSQLDataAccess
PostgreSQLDataAccess.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar los controladores para inyección de dependencias
builder.Services.AddScoped<ProductosController>();

// Agregar servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Configurar puerto dinámico según Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();

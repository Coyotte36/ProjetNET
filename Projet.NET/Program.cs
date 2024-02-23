using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.OpenApi.Models;
using Infrastructure.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);

// Log configuration
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Database configuration
builder.Services.AddDbContext<DbContext, ApplicationDbContext>(o =>
{
    o.UseSqlite(Environment.GetEnvironmentVariable("DATABASE_URL"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DbContext>();
    context.Database.Migrate();
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
app.UseBlazorFrameworkFiles();
// Cette permet d�h�berger des fichiers statics (css, js, �)
app.UseStaticFiles();

// Cette ligne existe d�j� pour les contr�leurs WebAPI app.MapControllers();
// Permet de rediriger toute adresse inconnue (dont / ) vers /index.html qui est la page par d�faut de notre client
app.MapFallbackToFile("index.html");

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

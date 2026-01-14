using GameHistory.Models;
using GameHistory.Repositories.Implementations;
using GameHistory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Connexion à la base MySQL (phrase récupérée depuis appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Utilisation de MySQL avec détection automatique de la version
builder.Services.AddDbContext<GamerHistoryContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ✅ Injection du Repository Pattern (IUserRepository → UserRepository)
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ✅ Ajout CORS pour autoriser Angular (http://localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Origine Angular
            .AllowAnyHeader()                     // Autorise tous les headers
            .AllowAnyMethod();                    // Autorise toutes les méthodes HTTP
    });
});

// ✅ Ajout des services pour les contrôleurs et Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Swagger activé en mode développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Active CORS avant les endpoints
app.UseCors("AllowAngular");

// ✅ Redirection HTTPS (si certificat configuré)
app.UseHttpsRedirection();

// ✅ Activation des contrôleurs
app.MapControllers();

// ✅ Lancement de l'application
app.Run();
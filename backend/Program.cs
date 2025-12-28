using backend;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.Build.Framework;
using System.Text.Json;

Env.Load();

bool production = Environment.GetEnvironmentVariable("PRODUCTION") == "true";

var builder = WebApplication.CreateBuilder(args);

if (production)
{
    Console.WriteLine("Running in Production mode");
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
}
else
{
    Console.WriteLine("Running in Development mode");
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
}

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddDbContext<AppDbContext>(optionsbuilder =>
{
    // string dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER env is not set");
    // string dbName = Environment.GetEnvironmentVariable("DB_NAME")  ?? throw new InvalidOperationException("DB_NAME env is not set");
    // string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER env is not set");
    // string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD env is not set");
    // optionsbuilder.UseSqlServer(
    //     $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=Yes;"
    // );

    optionsbuilder.UseSqlite(@"Data Source=Database.db");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "frontendPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Test database connection on startup
using (var scope = app.Services.CreateScope())
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nTesting database connection...");
    
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (context.Database.CanConnect())
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nSuccessfully connected to the database!\n\n");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nFailed to connect to the database: {context.Database.GetDbConnection().ConnectionString}\n\n");
        return;
    }
}

Console.ResetColor();

app.UseCors("frontendPolicy");
app.MapControllers();
app.Run();
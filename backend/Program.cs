using backend;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<AppDbContext>(opttionsbuilder =>
{
    string dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER env is not set");
    string dbName = Environment.GetEnvironmentVariable("DB_NAME")  ?? throw new InvalidOperationException("DB_NAME env is not set");
    string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER env is not set");
    string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD env is not set");
    opttionsbuilder.UseSqlServer(
        $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=Yes;"
    );
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

app.UseCors("frontendPolicy");
app.MapControllers();
app.Run();
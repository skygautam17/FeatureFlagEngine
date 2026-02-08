using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using MediatR;
using System.Reflection;
using Serilog;
using FeatureFlagEngine.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<AuditInterceptor>();
bool useInMemory = builder.Configuration.GetValue<bool>("Database:UseInMemory");

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{

    var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();

    if (useInMemory)
    {
        options.UseInMemoryDatabase("FeatureFlags");
    }
    else
    {
        var connString = builder.Configuration.GetConnectionString("DefaultConnection")
                         ?? builder.Configuration["Database:SqlServerConnection"];

        options.UseSqlServer(connString);
    }

    // Apply interceptor for BOTH providers
    options.AddInterceptors(interceptor);
});

builder.Services.AddScoped<IAppDbContext>(provider =>
    provider.GetRequiredService<AppDbContext>());


bool isRedisEnabled = builder.Configuration.GetValue<bool>("Redis:IsEnabled");

if (isRedisEnabled)
{
    string redisConn = builder.Configuration["Redis:ConnectionString"];
    if (redisConn != null)
    {
        builder.Services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(redisConn));
    }
}

var applicationAssembly = Assembly.Load("FeatureFlagEngine.Application");
var infrastructureAssembly = Assembly.Load("FeatureFlagEngine.Infrastructure");

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(applicationAssembly, infrastructureAssembly));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.ApplyMigrations();
}

app.UseSerilogRequestLogging();   // Logs HTTP requests

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAngular");

app.MapHealthChecks("/health");

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.MapControllers();
app.Run();

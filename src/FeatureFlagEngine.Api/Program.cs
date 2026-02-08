using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("FeatureFlags"));

string redisConn = builder.Configuration["Redis:ConnectionString"];
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(redisConn));

// Register MediatR
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var applicationAssembly =
    Assembly.Load("FeatureFlagEngine.Application");

var infrastructureAssembly =
    Assembly.Load("FeatureFlagEngine.Infrastructure");

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        applicationAssembly,
        infrastructureAssembly
    ));

// Correct CORS
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

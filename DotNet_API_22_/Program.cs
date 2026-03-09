using DotNet_API_22_.Data;
using DotNet_API_22_.Helper.JwtHelper;
using DotNet_API_22_.Service.AuthService;
using DotNet_API_22_.Service.SchoolService;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EduHubDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ISchoolService, SchoolService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    

builder.Services.AddScoped<IJwtHelper,JwtHelper>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "EduHubCache_";
});

builder.Services.AddRateLimiter(options =>
{
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        await context.HttpContext.Response.WriteAsync("Too many requests");
    };
    options.AddTokenBucketLimiter("token", opt =>
    {
        opt.TokenLimit = 10;
        opt.QueueLimit = 2;
        opt.ReplenishmentPeriod = TimeSpan.FromSeconds(1);
        opt.TokensPerPeriod = 1;


    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

app.Run();

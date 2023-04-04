using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Poliza.Models;
using Poliza.Repositories;
using Poliza.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<PolicyRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<JwtService>();

var builders = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builders.Build();

var connectionString = configuration.GetConnectionString("StringConnection");
var issuer = configuration["Jwt:Issuer"];
var audience = configuration["Jwt:Audience"];
var key = configuration["Jwt:Key"];


builder.Services.AddDbContext<PolicyContextEntity>(opt =>
    opt.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = issuer,
               ValidAudience = audience,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
           };
       });

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

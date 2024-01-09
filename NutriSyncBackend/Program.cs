using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NutriSyncBackend.DatabaseServices;
using NutriSyncBackend.Models;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

builder.Services.AddDbContext<NutriSyncDbContext>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<NutriSyncDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    // Set the default authentication scheme to JwtBearer
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Configure JWT Bearer authentication options
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("NUTRISYNC_JWT_ISSUER_SIGNING_KEY"))),
        ValidIssuer = Environment.GetEnvironmentVariable("NUTRISYNC_JWT_VALID_ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("NUTRISYNC_JWT_VALID_AUDIENCE")
    };
});

#endregion

var app = builder.Build();

#region Run

app.Run();

#endregion
using Microsoft.AspNetCore.Identity;
using NutriSyncBackend.DatabaseServices;
using NutriSyncBackend.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<NutriSyncDbContext>()
    .AddDefaultTokenProviders();
    
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//JwtSecurityTokenHandler.DefaultMapInboundClaims = false; //Jwt sub deðerini elde edip mappingi kaldýrma.

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
//{
//    opt.Authority = builder.Configuration["IdentityServerUrl"];
//    opt.Audience = "ResourceOrder";
//    opt.RequireHttpsMetadata = false;
//});

// Add services to the container.
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
//    opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

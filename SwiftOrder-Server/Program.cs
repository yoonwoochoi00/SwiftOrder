using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

using SwiftOrder_Server.Data;
using SwiftOrder_Server.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SwiftOrderDbContext>(options => options.UseSqlite(builder.Configuration["WebAPIConnection"]));
builder.Services.AddScoped<ISwiftOrderRepo, SwiftOrderRepo>();

// register authentication handler
builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, RestaurantHandler>("LoginScheme", null);

// reguster authorization policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("emailAddress"));
});

var app = builder.Build();

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

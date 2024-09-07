using System.Text.Json;
using LoginDemo.DatabaseServices;
using LoginDemo.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.Configure<MapAppDatabaseSettings>(
    builder.Configuration.GetSection("MapAppDatabase"));
builder.Services.AddTransient<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseCors(myAllowSpecificOrigins);


app.Run();

public class LoginInfo
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
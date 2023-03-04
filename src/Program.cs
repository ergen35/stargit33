using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinimalAPIS.Models;
using MinimalAPIS.Data;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var conStr = builder.Configuration.GetConnectionString("stargit");


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(conStr, sqliteOptions => 
    {
        sqliteOptions.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });

});

var app = builder.Build();

app.MapGet("/get_json", (req) =>
{
    return req.Response.WriteAsJsonAsync(new { hello = "barnabew" });
});



app.MapControllers();


app.Run();

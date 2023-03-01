using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinimalAPIS.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PersonContext>(opt =>
    opt.UseInMemoryDatabase("Minimals"));

var app = builder.Build();

app.MapGet("/get_json", (req) =>
{
    return req.Response.WriteAsJsonAsync(new { hello = "barnabew" });
});



app.MapControllers();


app.Run();

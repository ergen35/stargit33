using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/get_json", (req) =>
{
    return req.Response.WriteAsJsonAsync(new { hello = "barnabew" });
});

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

app.MapGet("/get_json", (req) =>
{
    return req.Response.WriteAsJsonAsync(new { hello = "barnabew" });
});

app.Run();

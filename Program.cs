using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/getAll", () => "ici toutes les todo");
app.MapGet("/getById", () => "ici une todo par son id");
app.MapGet("/getActives", () => "ici toutes les todo actives");
app.MapDelete("/delete", () => "ici supprimer une todo par son id");
app.MapPost("/post", () => "créer une todo");
app.MapPut("/put", () => "modifier une todo");


app.Run();
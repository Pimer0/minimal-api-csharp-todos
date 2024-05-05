
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using minimal_api_csharp_todos;
using minimal_api_csharp_todos.data.models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
var loggerConfiguration = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt");
var logger = loggerConfiguration.CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.MapPost("/person", (
    [FromBody] Person p,
    [FromServices] IValidator<Person> validator) =>
{
    var result = validator.Validate(p);
    if (!result.IsValid)
    {
        return Results.BadRequest(result.Errors);
    }
    return Results.Ok(p);
});

#region hello
/*app.MapGet("/hello", ([FromServices] ILogger<Program> logger) =>
    {
        logger.LogInformation("je suis un log");
        return Results.Ok("hello world");
    }
);*/
#endregion

app.MapGet("/getAll", ([FromServices] TodoService service) =>
{
    var todos = service.GetAll();
    return Results.Ok(todos);
}
);

app.MapGet("/getActives", ([FromServices] TodoService service, bool isActive) =>
{
    var todo = service.GetActives();
    if (todo.Any()) return Results.Ok(todo);
    return Results.NotFound();
});

app.MapDelete("/delete/{id:int}", ([FromServices] TodoService service, int id) =>
{
    service.Delete(id);
    return Results.Ok("todo supprimée");
});

app.MapPost("/todos", (ToDo t, TodoService service) =>
{
    if (t.Title is null)
    {
        return Results.BadRequest("Title cannot be null");
    }

    var result = service.Add(t.Title, t.IsActive);
    return Results.Ok(result);
});

app.MapPut("/put/{id:int}", ([FromServices] TodoService service, int id, ToDo updatedTodo) =>
{
    var todo = service.GetById(id);
    if (todo is null) return Results.NotFound("Todo non trouvé");

    if (updatedTodo.Title is null)
    {
        return Results.BadRequest("Title cannot be null");
    }

    service.Update(id, updatedTodo.Title, updatedTodo.IsActive);
    return Results.Ok("Todo mis à jour");
});

app.MapGet("/getById/{id:int}", ([FromServices] TodoService service, int id) =>
{
    var todo = service.GetById(id);
    if (todo is not null) return Results.Ok(todo);
    return Results.NotFound();
});
app.Run();
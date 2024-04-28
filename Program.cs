using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using minimal_api_csharp_todos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.MapGet("/getAll", ([FromServices] TodoService service) =>
{
    var todos = service.GetAll();
    return Results.Ok(todos);
}
);

app.MapGet("/getActives", ([FromServices] TodoService service, bool IsActive) =>
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
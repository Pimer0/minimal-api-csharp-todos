using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace minimal_api_csharp_todos
{
    public record class ToDo(int Id, string? Title, bool IsActive)
    {


        /*         public static bool TryParse(string? value, out ToDo toDo)
                {
                    try
                    {
                        var data = value?.Split(" ");
                        toDo = new ToDo(
                            Id: int.Parse(data?[0] ?? throw new ArgumentNullException(nameof(value))),
                            Title: data?[1] ?? throw new ArgumentNullException(nameof(value)),
                            IsActive: bool.Parse(data?[2] ?? throw new ArgumentNullException(nameof(value)))
                        );
                        return true;
                    }
                    catch
                    {
                        toDo = null!;
                        return false;
                    }
                }

                public static async ValueTask<ToDo> BindAsync(HttpContext context, ParameterInfo parameterInfo)
                {
                    try
                    {
                        using var reader = new StreamReader(context.Request.Body);
                        var content = await reader.ReadToEndAsync();
                        var data = content.Split(" ");
                        var toDo = new ToDo(
                            Id: int.Parse(data[0]),
                            Title: data[1],
                            IsActive: bool.Parse(data[2])
                        );
                        return toDo;
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync($"Invalid data: {ex.Message}");
                        return null!;
                    }
                } */
    }
}

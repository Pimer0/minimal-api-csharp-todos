using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace minimal_api_csharp_todos
{
    public class TodoService
    {
        private List<ToDo> _todos = new List<ToDo> {
            new ToDo(1, "Faire les courses", true),
            new ToDo(2, "Acheter du pain", true),
            new ToDo(3, "Acheter du lait", false),
        };

        public List<ToDo> GetAll()
        {
            return _todos;
        }

        public List<ToDo> GetActives()
        {
            return _todos.Where(t => t.IsActive).ToList();
        }

        public ToDo GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if (todo is not null)
            {
                _todos.Remove(todo);
            }
        }

        public List<ToDo> GetAllTodos() => _todos;

        public ToDo Add(string title, bool IsActive)
        {
            var todo = new ToDo(_todos.Max(a => a.Id) + 1, title, IsActive);
            _todos.Add(todo);
            return todo;
        }

public void Update(int id, string title, bool isActive)
{
    var todo = _todos.FirstOrDefault(t => t.Id == id);
    if (todo is null) throw new Exception("Todo non trouvé");

    var updatedTodo = new ToDo(todo.Id, title, isActive);
    _todos[_todos.IndexOf(todo)] = updatedTodo;
}


    }
}
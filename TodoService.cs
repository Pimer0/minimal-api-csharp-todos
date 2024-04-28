using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace minimal_api_csharp_todos
{
    public class TodoService
    {
        private List<ToDo> _todos = new List<ToDo> {
            new ToDo { Id = 1, Title = "Faire les courses", IsActive = true},
            new ToDo { Id = 2, Title = "Acheter du pain", IsActive = true},
        };

        public List<ToDo> GetAll()
        {
            return _todos;
        }

        public ToDo? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public List<ToDo> GetActives()
        {
            return _todos.Where(t => t.IsActive).ToList();
        }

        public void Post()
        {
            var newTodo = new ToDo();
            newTodo.Id = _todos.Max(t => t.Id) + 1;
            newTodo.Title = "New Todo";
            newTodo.IsActive = true;
            _todos.Add(newTodo);
            return;
        }

    }
}
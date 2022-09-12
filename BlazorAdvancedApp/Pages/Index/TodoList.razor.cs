using BlazorAdvancedApp.Pages.Index.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorAdvancedApp.Pages.Index
{
    public partial class TodoList
    {
        public string TodoText { get; set; }
        public IReadOnlyList<Todo> Todos { get; private set; } = new List<Todo>();
        public bool IsEditMode { get; set; } = false;
        public int UpdateTodoIndex { get; private set; } = -1;

        public string JokeText { get; set; } = string.Empty;

        [Inject]
        public IChucknorrisService ChucknorrisService { get; set; }

        public void AddTodo()
        {
            var todos = new List<Todo>(Todos) { new Todo(TodoText) };
            Todos = todos.AsReadOnly();

            TodoText = string.Empty;
        }

        public async Task RemoveTodo(int todoIndex)
        {
            var todos = new List<Todo>(Todos);
            todos.RemoveAt(todoIndex);

            Todos = todos.AsReadOnly();

            var joke = await ChucknorrisService.LoadJokeAsync();
            JokeText = joke.value;
        }

        public void EditTodo(int todoIndex)
        {
            IsEditMode = true;
            TodoText = Todos[todoIndex].Text;
            UpdateTodoIndex = todoIndex;
        }

        public void UpdateTodo()
        {
            var todos = new List<Todo>(Todos);
            todos[UpdateTodoIndex] = new Todo(TodoText);
            Todos = todos.AsReadOnly();

            TodoText = string.Empty;
            IsEditMode = false;
            UpdateTodoIndex = -1;
        }
    }

    public record Todo(string Text);
}
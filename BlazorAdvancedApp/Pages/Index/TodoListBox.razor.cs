using Microsoft.AspNetCore.Components;
using BlazorComponentUtilities;

namespace BlazorAdvancedApp.Pages.Index
{
    public partial class TodoListBox
    {
        [Parameter]
        public IReadOnlyList<Todo> Todos { get; set; } = new List<Todo>();

        [Parameter]
        public EventCallback<int> EditTodoClick { get; set; }

        [Parameter]
        public EventCallback<int> RemoveTodoClick { get; set; }

        [Parameter]
        public int UpdateTodoIndex { get; set; } = -1;

        public async Task EditTodo(int todoIndex)
        {
            var todos = new List<Todo>(Todos);
            todos[todoIndex] = new Todo("I hacked you! Muahaha");
            Todos = todos.AsReadOnly();

            await EditTodoClick.InvokeAsync(todoIndex);
        }

        public async Task RemoveTodo(int todoIndex)
        {
            //Todos.RemoveAt(todoIndex);
            await RemoveTodoClick.InvokeAsync(todoIndex);
        }

        public string EditItemStyles(int todoIndex)
        {
            return new CssBuilder()
                .AddClass("edit-item", todoIndex == UpdateTodoIndex)
                .AddClass("item", todoIndex != UpdateTodoIndex)
                .AddClass("text-bold")
                .Build();
        }
    }
}
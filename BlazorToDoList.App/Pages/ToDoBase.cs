using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorToDoList.App.Pages
{
    public class ToDoBase : ComponentBase
    {
        [Inject] protected HttpClient Http { get; set; }

        protected IList<ToDoItem> items = new List<ToDoItem>();
        protected string newItem;

        /// <summary>
        /// This method is responsible for loading the initial data the page requires.  We store this sample data
        /// in a JSON file.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitAsync()
        {
            items = await Http.GetJsonAsync<List<ToDoItem>>("sample-data/todoitems.json");
        }

        /// <summary>
        /// This method adds a new ToDo item.
        /// </summary>
        protected void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(newItem))
            {
                items.Add(new ToDoItem()
                {
                    DateCreated = DateTime.Now,
                    Description = newItem,
                    ID = Guid.NewGuid()
                });

                newItem = string.Empty; //We need to reset this string, otherwise the text box will still contain the value typed in.
            }
        }

        protected void ToggleToDo(Guid id)
        {
            //First find the item
            var todo = items.First(x => x.ID == id);
            todo.IsComplete = !todo.IsComplete;
        }

        protected void RemoveTodo(Guid id)
        {
            items.Remove(items.First(x => x.ID == id));
        }

        protected class ToDoItem
        {
            public Guid ID { get; set; }
            public string Description { get; set; }
            public bool IsComplete { get; set; }
            public DateTime DateCreated { get; set; }
        }
    }
}
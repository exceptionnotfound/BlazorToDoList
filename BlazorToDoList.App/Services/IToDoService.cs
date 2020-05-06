using BlazorToDoList.App.Models;
using System;
using System.Collections.Generic;

namespace BlazorToDoList.App.Services
{
    public interface IToDoService
    {
        List<ToDoItem> Get();
        ToDoItem Get(Guid ID);
        List<ToDoItem> Add(ToDoItem toDoItem);
        List<ToDoItem> Toggle(Guid id);
        List<ToDoItem> Delete(Guid ID);

    }
}

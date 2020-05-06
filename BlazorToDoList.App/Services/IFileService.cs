using BlazorToDoList.App.Models;
using System.Collections.Generic;

namespace BlazorToDoList.App.Services
{
    public interface IFileService
    {
        string ReadFromFile();
        void SaveToFile(List<ToDoItem> toDoItems);
    }
}

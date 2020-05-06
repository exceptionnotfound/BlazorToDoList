using BlazorToDoList.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorToDoList.App.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IFileService _fileService;
        private List<ToDoItem> _toDoItems;

        public ToDoService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<ToDoItem> Get()
        {
            string json = _fileService.ReadFromFile();
            _toDoItems = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            return _toDoItems;
        }

        public ToDoItem Get(Guid ID)
        {
            return _toDoItems.First(x => x.ID == ID);
        }

        public List<ToDoItem> Add(ToDoItem toDoItem)
        {
            _toDoItems.Add(toDoItem);
            _fileService.SaveToFile(_toDoItems);
            return _toDoItems;
        }

        public List<ToDoItem> Toggle(Guid ID)
        {
            var toDoItemToUpdate = Get(ID);

            if (toDoItemToUpdate != null)
            {
                toDoItemToUpdate.IsComplete = !toDoItemToUpdate.IsComplete;
                _fileService.SaveToFile(_toDoItems);
            }

            return _toDoItems;
        }

        public List<ToDoItem> Delete(Guid ID)
        {
            var toDoItemToRemove = Get(ID);

            if(toDoItemToRemove != null)
            {
                _toDoItems.Remove(Get(ID));
                _fileService.SaveToFile(_toDoItems);
            }

            return _toDoItems;
        }
    }
}


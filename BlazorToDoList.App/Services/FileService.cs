using BlazorToDoList.App.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BlazorToDoList.App.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ReadFromFile()
        {
            return File.ReadAllText(_configuration["SampleDataFile"]);
        }

        public void SaveToFile(List<ToDoItem> toDoItems)
        {
            string json = JsonConvert.SerializeObject(toDoItems);
            System.IO.File.WriteAllText(_configuration["SampleDataFile"], json);
        }
    }
}

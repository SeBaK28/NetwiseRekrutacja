using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Model;

namespace api.Services
{
    public class FileStorageService : IFileStorageService
    {
        public async Task SaveToFileAsync(CatFact model)
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "data.txt");

            string content = $"Fact: {model.Fact}; Length: {model.Length} \n";

            await File.AppendAllTextAsync(filePath, content);
        }
    }
}
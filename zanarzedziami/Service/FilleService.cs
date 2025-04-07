using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;
using zanarzedziami.Model;


namespace zanarzedziami.Service
{
    public class FileService
    {
        public ObservableCollection<Tool> Tools { get; private set; } = new();
        private readonly string _filePath;

        public FileService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "tools.json");
        }

        public async Task LoadToolsAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                var loadedTools = JsonSerializer.Deserialize<ObservableCollection<Tool>>(json);
                Tools = loadedTools ?? new ObservableCollection<Tool>();
            }
        }

        public async Task SaveToolsAsync()
        {
            var json = JsonSerializer.Serialize(Tools, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}

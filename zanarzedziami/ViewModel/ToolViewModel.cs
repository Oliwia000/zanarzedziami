using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using zanarzedziami.Model;
using zanarzedziami.Service;
using System.Collections.ObjectModel;
using zanarzedziami.View;


namespace zanarzedziami.ViewModel
{
    public class ToolViewModel
    {
        private readonly FileService _fileService;

        public ObservableCollection<Tool> Tools => _fileService.Tools;
        public Tool SelectedTool { get; set; }

        /// <summary>
        /// widok modelu narzędzi, który przyjmuje serwis plików.
        /// </summary>
        /// <param name="fileService">Serwis plików do obsługi zapisu i odczytu narzędzi.</param>
        public ToolViewModel(FileService fileService)
        {
            _fileService = fileService;
        }

        public async Task LoadDataAsync()
        {
            await _fileService.LoadToolsAsync();
        }

        /// <summary>
        /// Dodaje nowe narzędzie do kolekcji narzędzi i zapisuje zmiany w pliku.
        /// </summary>
        /// <param name="tool">Obiekt narzędzia, który ma zostać dodany.</param>
        public async Task AddToolAsync(Tool tool)
        {
            tool.Id = Tools.Count > 0 ? Tools.Max(t => t.Id) + 1 : 1;
            Tools.Add(tool);
            await _fileService.SaveToolsAsync();
        }


        /// <summary>
        /// Aktualizuje istniejące narzędzie w kolekcji i zapisuje zmiany w pliku.
        /// </summary>
        /// <param name="tool">Obiekt narzędzia, który ma zostać zaktualizowany</param>
        public async Task UpdateToolAsync(Tool tool)
        {
            var existingTool = Tools.FirstOrDefault(t => t.Id == tool.Id); // Szukanie narzędzia o tym samym identyfikatorze.
            if (existingTool != null)
            {
                existingTool.Name = tool.Name;
                existingTool.Quantity = tool.Quantity;
                existingTool.Price = tool.Price;
                await _fileService.SaveToolsAsync(); // Zapisanie zmienionych danych
            }
        }

        /// <summary>
        /// Usuwa narzędzie z kolekcji i zapisuje zmiany w pliku.
        /// </summary>
        /// <param name="tool">Obiekt narzędzia, które ma zostać usunięte.</param>
        public async Task DeleteToolAsync(Tool tool)
        {
            Tools.Remove(tool); // Usunięcie narzędzia z kolekcji
            await _fileService.SaveToolsAsync();   // Zapisanie zmienionej kolekcji narzędzi
        }
    }
}

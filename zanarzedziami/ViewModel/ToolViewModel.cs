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

        public ToolViewModel(FileService fileService)
        {
            _fileService = fileService;
        }

        public async Task LoadDataAsync()
        {
            await _fileService.LoadToolsAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>
        public async Task AddToolAsync(Tool tool)
        {
            tool.Id = Tools.Count > 0 ? Tools.Max(t => t.Id) + 1 : 1;
            Tools.Add(tool);
            await _fileService.SaveToolsAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>
        public async Task UpdateToolAsync(Tool tool)
        {
            var existingTool = Tools.FirstOrDefault(t => t.Id == tool.Id);
            if (existingTool != null)
            {
                existingTool.Name = tool.Name;
                existingTool.Quantity = tool.Quantity;
                existingTool.Price = tool.Price;
                await _fileService.SaveToolsAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>
                public async Task DeleteToolAsync(Tool tool)
        {
            Tools.Remove(tool);
            await _fileService.SaveToolsAsync();
        }
    }
}

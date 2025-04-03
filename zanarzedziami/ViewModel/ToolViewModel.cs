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

namespace zanarzedziami.ViewModel
{
    public class ToolViewModel
    {
        private const string FilePath = "tools.json";
        public ObservableCollection<Tool> Tools { get; set; } = new ObservableCollection<Tool>();
        public Tool SelectedTool { get; set; }
        public ToolViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var tools = JsonSerializer.Deserialize<List<Tool>>(json) ?? new List<Tool>();
                foreach (var tool in tools)
                {
                    Tools.Add(tool);
                }
            }
        }
        public void SaveData()
        {
            string json = JsonSerializer.Serialize(Tools.ToList(), new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void AddTool(Tool tool)
        {
            tool.Id = Tools.Count > 0 ? Tools.Max(t => t.Id) + 1 : 1;
            Tools.Add(tool);
            SaveData();
        }

        public void UpdateTool(Tool tool)
        {
            var existingTool = Tools.FirstOrDefault(t => t.Id == tool.Id);
            if (existingTool != null)
            {
                existingTool.Name = tool.Name;
                existingTool.Quantity = tool.Quantity;
                existingTool.Price = tool.Price;
                SaveData();
            }
        }

        public void DeleteTool(Tool tool)
        {
            Tools.Remove(tool);
            SaveData();
        }
    }
}




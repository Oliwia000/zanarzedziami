using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using zanarzedziami.Model;
using zanarzedziami.Service;
using zanarzedziami.View;
using Microsoft.Maui.Controls;

namespace zanarzedziami.ViewModel
{
    public class MainViewModel : BindableObject
    {
        private readonly INavigation _navigation;
        private readonly FileService _fileService;

        public ObservableCollection<Tool> Tools => _toolViewModel.Tools;

        public ICommand AddToolCommand { get; }
        public ICommand ToolTappedCommand { get; }

        private ToolViewModel _toolViewModel;
        private Tool _selectedTool;

        public Tool SelectedTool
        {
            get => _selectedTool;
            set
            {
                _selectedTool = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _fileService = new FileService();
            _toolViewModel = new ToolViewModel(_fileService);

            AddToolCommand = new Command(async () => await AddTool());
            ToolTappedCommand = new Command(async () => await OpenToolDetail());

            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await _toolViewModel.LoadDataAsync();
            OnPropertyChanged(nameof(Tools));
        }

        private async Task AddTool()
        {
            await _navigation.PushAsync(new AddToolPage(_toolViewModel));
        }

        private async Task OpenToolDetail()
        {
            if (SelectedTool != null)
            {
                await _navigation.PushAsync(new ToolDetailPage(SelectedTool, _toolViewModel));
                SelectedTool = null; // reset selection
            }
        }
    }
}

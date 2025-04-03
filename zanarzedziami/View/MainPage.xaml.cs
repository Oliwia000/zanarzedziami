using Microsoft.Maui.Controls;
using zanarzedziami.ViewModel;
using zanardzediami.Model;

namespace zanardzediami.View
{
    public partial class MainPage : ContentPage
    {
        private ToolViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new ToolViewModel();
            BindingContext = viewModel;
        }

        private void AddTool(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddToolPage(viewModel));
        }

        private void ToolSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Tool selectedTool)
            {
                Navigation.PushAsync(new ToolDetailPage(selectedTool, viewModel));
            }
        }

        private void ShowSingleTool(object sender, EventArgs e)
        {
            if (viewModel.Tools.Any())
            {
                Tool firstTool = viewModel.Tools.First();
                Navigation.PushAsync(new ToolDetailPage(firstTool, viewModel));
            }
        }
           
       
    }
    }


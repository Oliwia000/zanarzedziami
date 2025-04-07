using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using zanarzedziami.Model;
using zanarzedziami.ViewModel;
using zanarzedziami.Service;

namespace zanarzedziami.View
{
    public partial class AddToolPage : ContentPage
    {
        private ToolViewModel viewModel;
        private Tool newTool;

        public AddToolPage(ToolViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            newTool = new Tool();
            BindingContext = newTool;
        }

        private async void SaveTool(object sender, EventArgs e)
        {
            await viewModel.AddToolAsync(newTool);
            await Navigation.PopAsync();
        }
    }
}








using Microsoft.Maui.Controls;
using zanardzediami.Model;
using zanarzedziami.ViewModel;

namespace zanardzediami.View
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
            viewModel.AddTool(newTool);
            await Navigation.PopAsync();
        }
    }
}

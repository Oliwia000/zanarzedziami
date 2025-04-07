using Microsoft.Maui.Controls;
using zanarzedziami.Model;
using Microsoft.Maui.Controls.Xaml;
using zanarzedziami.ViewModel;
using zanarzedziami.Service;
using zanarzedziami.ViewModel;

namespace zanarzedziami.View
{
    public partial class ToolDetailPage : ContentPage
    {
        private Tool tool;
        private ToolViewModel viewModel;

        public ToolDetailPage(Tool selectedTool, ToolViewModel vm)
        {
            InitializeComponent();
            tool = selectedTool;
            viewModel = vm;
            BindingContext = tool;
        }

        private async void DeleteTool(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Potwierdzenie", "Na pewno usun¹æ?", "Tak", "Nie");
            if (confirm)
            {
                await viewModel.DeleteToolAsync(tool);
                await Navigation.PopAsync();
            }
        }

        private async void UpdateTool(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Potwierdzenie", "Zaktualizowaæ narzêdzie?", "Tak", "Nie");
            if (confirm)
            {
                await viewModel.UpdateToolAsync(tool);
                await Navigation.PopAsync();
            }
        }
    }
}



//SkyBlue-kolor







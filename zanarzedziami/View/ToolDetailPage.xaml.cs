using Microsoft.Maui.Controls;
using zanardzediami.Model;
using zanarzedziami.ViewModel;

namespace zanardzediami.View
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
            bool confirmed = await DisplayAlert("Potwierdzenie", "Czy na pewno chcesz usun¹æ to narzêdzie?", "Tak", "Nie");
            if (confirmed)
            {
                viewModel.DeleteTool(tool);
                await Navigation.PopAsync();
            }
        }

        private async void UpdateTool(object sender, EventArgs e)
        {
            bool confirmed = await DisplayAlert("Potwierdzenie", "Czy na pewno chcesz zaktualizowaæ to narzêdzie?", "Tak", "Nie");
            if (confirmed)
            {
                viewModel.UpdateTool(tool);
                await Navigation.PopAsync();
            }
        }
    }
}

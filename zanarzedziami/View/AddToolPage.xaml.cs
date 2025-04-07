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

        /// <summary> Konstruktor strony, ustawia kontekst danych na nowe narzêdzie. </summary>
        /// <param name="vm">Widok modelu zawieraj¹cy logikê aplikacji dla narzêdzi.</param>
        public AddToolPage(ToolViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            newTool = new Tool();
            BindingContext = newTool;  // Ustawienie kontekstu danych na nowe narzêdzie.
        }

        /// <summary>
        /// Obs³uguje klikniêcie przycisku zapisywania narzêdzia. Zapisuje nowe narzêdzie do systemu i wraca do poprzedniej strony.
        /// </summary>
        /// <param name="sender">Obiekt, który wywo³a³ zdarzenie (np. przycisk).</param>
        /// <param name="e">Dodatkowe informacje</param>
        private async void SaveTool(object sender, EventArgs e)
        {
            await viewModel.AddToolAsync(newTool);
            await Navigation.PopAsync();
        }
    }
}








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

        /// <summary> Konstruktor strony, ustawia kontekst danych na nowe narz�dzie. </summary>
        /// <param name="vm">Widok modelu zawieraj�cy logik� aplikacji dla narz�dzi.</param>
        public AddToolPage(ToolViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            newTool = new Tool();
            BindingContext = newTool;  // Ustawienie kontekstu danych na nowe narz�dzie.
        }

        /// <summary>
        /// Obs�uguje klikni�cie przycisku zapisywania narz�dzia. Zapisuje nowe narz�dzie do systemu i wraca do poprzedniej strony.
        /// </summary>
        /// <param name="sender">Obiekt, kt�ry wywo�a� zdarzenie (np. przycisk).</param>
        /// <param name="e">Dodatkowe informacje</param>
        private async void SaveTool(object sender, EventArgs e)
        {
            await viewModel.AddToolAsync(newTool);
            await Navigation.PopAsync();
        }
    }
}








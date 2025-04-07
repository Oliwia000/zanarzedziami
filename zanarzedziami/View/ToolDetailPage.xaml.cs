using Microsoft.Maui.Controls;
using zanarzedziami.Model;
using Microsoft.Maui.Controls.Xaml;
using zanarzedziami.ViewModel;
using zanarzedziami.Service;

namespace zanarzedziami.View
{

    public partial class ToolDetailPage : ContentPage
    {
        private Tool tool;
        private ToolViewModel viewModel;


        /// <summary>
        /// Konstruktor strony szczeg��w narz�dzia.Widok modelu oraz ustawia kontekst danych na wybrane narz�dzie.
        /// </summary>
        /// <param name="selectedTool">Obiekt narz�dzia, kt�rego szczeg�y b�d� wy�wietlane.</param>
        /// <param name="vm">Widok modelu zawieraj�cy logik� aplikacji dla narz�dzi</param>
        public ToolDetailPage(Tool selectedTool, ToolViewModel vm)
        {
            InitializeComponent();
            tool = selectedTool;
            viewModel = vm;
            BindingContext = tool;
        }

        /// <summary>
        /// Obs�uguje klikni�cie przycisku usuwania narz�dzia. Potwierdza usuni�cie narz�dzia i wykonuje.
        /// </summary>
        /// <param name="sender">Obiekt, kt�ry wywo�a� zdarzenie </param>
        /// <param name="e">Dodatkowe informacje.</param>
        private async void DeleteTool(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Potwierdzenie", "Na pewno usun��?", "Tak", "Nie");
            if (confirm)
            {
                await viewModel.DeleteToolAsync(tool);  //Je�li u�ytkownik potwierdzi, usuwamy narz�dzie
                await Navigation.PopAsync(); //Powr�t do poprzedniej strony
            }
        }


        /// <summary>
        /// Obs�uguje klikni�cie przycisku aktualizacji narz�dzia. Potwierdza aktualizacj� narz�dzia i wykonuje.
        /// </summary>
        /// <param name="sender">Obiekt, kt�ry wywo�a� zdarzenie</param>
        /// <param name="e">dodatkowe informacje</param>
        private async void UpdateTool(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Potwierdzenie", "Zaktualizowa� narz�dzie?", "Tak", "Nie");
            if (confirm)
            {
                await viewModel.UpdateToolAsync(tool);
                await Navigation.PopAsync();
            }
        }
    }
}



//SkyBlue-kolor







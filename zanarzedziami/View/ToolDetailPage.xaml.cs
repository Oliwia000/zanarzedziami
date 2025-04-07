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
        /// Konstruktor strony szczegó³ów narzêdzia.Widok modelu oraz ustawia kontekst danych na wybrane narzêdzie.
        /// </summary>
        /// <param name="selectedTool">Obiekt narzêdzia, którego szczegó³y bêd¹ wyœwietlane.</param>
        /// <param name="vm">Widok modelu zawieraj¹cy logikê aplikacji dla narzêdzi</param>
        public ToolDetailPage(Tool selectedTool, ToolViewModel vm)
        {
            InitializeComponent();
            tool = selectedTool;
            viewModel = vm;
            BindingContext = tool;
        }

        /// <summary>
        /// Obs³uguje klikniêcie przycisku usuwania narzêdzia. Potwierdza usuniêcie narzêdzia i wykonuje.
        /// </summary>
        /// <param name="sender">Obiekt, który wywo³a³ zdarzenie </param>
        /// <param name="e">Dodatkowe informacje.</param>
        private async void DeleteTool(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Potwierdzenie", "Na pewno usun¹æ?", "Tak", "Nie");
            if (confirm)
            {
                await viewModel.DeleteToolAsync(tool);  //Jeœli u¿ytkownik potwierdzi, usuwamy narzêdzie
                await Navigation.PopAsync(); //Powrót do poprzedniej strony
            }
        }


        /// <summary>
        /// Obs³uguje klikniêcie przycisku aktualizacji narzêdzia. Potwierdza aktualizacjê narzêdzia i wykonuje.
        /// </summary>
        /// <param name="sender">Obiekt, który wywo³a³ zdarzenie</param>
        /// <param name="e">dodatkowe informacje</param>
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







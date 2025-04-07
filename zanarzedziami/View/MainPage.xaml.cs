using Microsoft.Maui.Controls;
using zanarzedziami.ViewModel;



namespace zanarzedziami.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var viewModel = BindingContext as MainViewModel;
            viewModel?.ToolTappedCommand.Execute(null);
        }
    }
}

using System;
using Xamarin.Forms;

namespace AccentApp
{
    public partial class MainPage : ContentPage
    {
        public static Action CloseClicked; // delegate for closing app
        public MainPage()
        {
            InitializeComponent();
        }
        private async void StartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordsPage()); 
        }

        private async void DevButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeveloperPage());
        }

        private void CloseButtonClicked(object sender, EventArgs e)
        { 
            CloseClicked.Invoke();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

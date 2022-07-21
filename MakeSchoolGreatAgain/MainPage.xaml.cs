using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MakeSchoolGreatAgain
{
    public partial class MainPage : ContentPage
    {
        public static Action CloseClicked; // delegate for closing app
        bool loaded = false;
        public MainPage()
        {
            InitializeComponent();
        }
        private async void StartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordsPage());
        }

        private void DevButtonClicked(object sender, EventArgs e)
        {

        }

        private void CloseButtonClicked(object sender, EventArgs e)
        { 
            CloseClicked.Invoke();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (loaded == false)
                loaded = true;
        }
    }
}

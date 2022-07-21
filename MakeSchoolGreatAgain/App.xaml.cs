using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeSchoolGreatAgain
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            CheckForDict();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
        /// <summary>
        /// Checks if dictionary of words exists. If not create it.
        /// </summary>
        private void CheckForDict()
        {
            if (Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Contains("Dictionary.txt"))
                return;
            new DictionaryCreator(); // Constructor of DictionaryCreator creates a file
        }
    }
}

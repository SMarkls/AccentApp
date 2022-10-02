using AccentApp.Data;
using System;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccentApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordsPage : ContentPage
    {
        static string vowels = "АЕЁИОУЫЭЮЯ";
        static StackLayout buttonsStack;
        private Counter counter;

        public WordsPage()
        {
            InitializeComponent();
            counter = Resources["Counter"] as Counter;
            buttonsStack = this.FindByName<StackLayout>("ButtonsStack");
            if (WordLabel.Text == "")
                InitWord();
        }
        private void InitWord()
        {
            WordLabel.Text = "";
            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dictionary.txt");
            Random random = new Random();
            int num = random.Next(0, 268); // 268 - count of lines in Dictionary.txt
            string str = File.ReadLines(file).Skip(num).First();
            WordLabel.Text = str;
            InitButtons();
        }

        private void InitButtons()
        {
            buttonsStack.Children.Clear();
            foreach (char l in WordLabel.Text)
                if ((vowels+vowels.ToLower()).Contains(l))
                { 
                    var btn = new Button { Text = l.ToString(), Style = (Style)Resources["LetterButton"], TextTransform = TextTransform.Uppercase};
                    btn.Clicked += LetterClicked;
                    buttonsStack.Children.Add(btn);
                }
        }

        private void LetterClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (vowels.Contains(button.Text))
            {
                counter.Count++;
                InitWord();
            }
            else counter.Count = 0;
        }
        protected override void OnDisappearing()
        {
            counter.InvokeRecordEvent();
            base.OnDisappearing();
        }
    }
}
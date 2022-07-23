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
        int firstBestCount = 0;
        static int bestCount = 0;
        static int count = 0;
        static string vowels = "аеёиоуыэюя";
        static string upVowels = "АЕЁИОУЫЭЮЯ";
        static StackLayout stack;

        public WordsPage()
        {
            InitializeComponent();
            try
            {
                bestCount = Convert.ToInt32(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Record.txt")));
            }
            catch (Exception ex)
            {

            }
            firstBestCount = bestCount;
            EditValues();
            stack = this.FindByName<StackLayout>("ButtonsStack");
            if (WordLabel.Text == "")
                InitWord();
        }
        private void InitWord()
        {
            WordLabel.Text = "";
            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dictionary.txt");
            Random random = new Random();
            int num = random.Next(0, 65); // 65 - count of lines in Dictionary.txt
            string str = File.ReadLines(file).Skip(num).First();
            if (str.Contains(":"))
            { 
                str = str.Split(':')[0];
                //string desc = str.Split(':')[1]; // description after clicking button
            }
            str = str.Split(':')[0];
            WordLabel.Text = str;
            InitButtons();
            //catch (Exception ex)
            //{
            //    DisplayAlert("Уведомление", ex.ToString(), "ОK");
            //}
        }

        private void InitButtons()
        {
            stack.Children.Clear();
            foreach (char l in WordLabel.Text)
                if ((vowels+upVowels).Contains(l))
                { 
                    var instance = new Button { Text = l.ToString(), Style = (Style)Resources["LetterButton"], TextTransform = TextTransform.Uppercase};
                    instance.Clicked += LetterClicked;
                    stack.Children.Add(instance);
                }
        }

        private void LetterClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (upVowels.Contains(button.Text))
            {
                count++;
                InitWord();
                if (count > bestCount) bestCount = count;
            }
            else count = 0;
            EditValues();
        }

        private void EditValues()
        {
            BestLabel.Text = $"Лучший счёт: {bestCount}";
            CountLabel.Text = $"Ваш счёт: {count}";
        }

        protected override void OnDisappearing()
        {
            if (bestCount > firstBestCount)
                using (StreamWriter stream = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Record.txt"), false))
                    stream.Write(bestCount.ToString());
                base.OnDisappearing();
        }
    }
}
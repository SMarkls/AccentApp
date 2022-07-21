using System;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakeSchoolGreatAgain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordsPage : ContentPage
    {
        static int count = 0;
        static string vowels = "аеёиоуыэюя";
        static string upVowels = "АЕЁИОУЫЭЮЯ";
        static StackLayout stack;
        public WordsPage()
        {
            InitializeComponent();
            stack = this.FindByName<StackLayout>("ButtonsStack");
            InitWord();
            InitButtons();
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
                InitButtons();
                EditValues();
            }
        }

        private void EditValues()
        {
            // Todo: Check for best count
            CountLabel.Text = $"Ваш счёт: {count}";
        }
    }
}
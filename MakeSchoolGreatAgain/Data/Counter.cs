using System;
using System.ComponentModel;
using System.IO;

namespace AccentApp.Data
{
    class Counter : INotifyPropertyChanged
    {
        private int initalBestCount;
        private int count;
        private int bestCount;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                if (count > bestCount)
                {
                    bestCount = count;
                    OnPropertyChanged("BestCount");
                    if (RecordReached == null)
                        RecordReached += () =>
                        {
                            using (StreamWriter stream = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Record.txt"), false))
                                stream.Write(bestCount.ToString());
                        };
                }
                OnPropertyChanged("Count");
            }
        }
        public int BestCount => bestCount;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Counter()
        {
            count = 0;
            bestCount = 0;
            try
            {
                bestCount = Convert.ToInt32(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Record.txt")));
            }
            catch (Exception ex)
            {

            }
            initalBestCount = bestCount;
        }
        public event Action RecordReached;
        public void InvokeRecordEvent() => RecordReached?.Invoke();
    }
}

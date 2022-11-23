using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System;
using System.Windows;

namespace WpfLibrary.ViewModel
{
    public class AddJournalViewModel: ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand AddJournalCommand { get; set; }
        public int Year { get; set; }
        public int Edition { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public TopicType Topic { get; set; }
        public MonthType Month { get; set; }
        public LanguageType Language { get; set; }


        public AddJournalViewModel()
        {
            AddJournalCommand = new RelayCommand(AddJournal);
            items.AddItemAction = NotifySuccessMessage;
        }

        public void NotifySuccessMessage() => MessageBox.Show("Journal added");

        private void AddJournal()
        {
            try
            {
                items.AddJournal(Title, Publisher, Price, Edition, Language, Topic, Year, Month);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

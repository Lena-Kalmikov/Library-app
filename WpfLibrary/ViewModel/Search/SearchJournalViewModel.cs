using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Collections.ObjectModel;

namespace WpfLibrary.ViewModel
{
    public class SearchJournalViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand SearchItemCommand { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public int Edition { get; set; }
        public LanguageType Language { get; set; }
        public TopicType Topic { get; set; }
        public MonthType Month { get; set; }
        public int Year { get; set; }

        /* Since each type has it's own unique parameters, I wanted the user to see them in a table,
           and not only the basic parameters that are in AbstractItem.
           For example, Book has Genre and Author while AbstractItem does not.
           Journal has Publiser and Edition and Topic, Audiobook has 'Barrated by'.
           For this reason I created 3 Observable Collections - the user can see all the information.
           The search itself is done on AbstractItem List */
        public ObservableCollection<Journal> Journals { get; set; }

        public SearchJournalViewModel()
        {
            SearchItemCommand = new RelayCommand(Search);
            Journals = new ObservableCollection<Journal>();
        }

        public void Search()
        {
            Journals.Clear();

            foreach (AbstractItem item in items.SearchJournal(Title, Publisher, Price, Language, Year, Topic, Edition, Month))
            {
                Journal journal = (Journal)item;
                journal.JournalPrice = journal.GetPrice();
                Journals.Add(journal);
            }
        }
    }
}


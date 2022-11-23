using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Collections.ObjectModel;

namespace WpfLibrary.ViewModel
{
    public class GeneralSearchViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand SearchItemCommand { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public LanguageType Language { get; set; }
        public int Year { get; set; }

        public ObservableCollection<AbstractItem> Items { get; set; }

        public GeneralSearchViewModel()
        {
            SearchItemCommand = new RelayCommand(Search);
            Items = new ObservableCollection<AbstractItem>();
        }

        public void Search()
        {
            Items.Clear();

            foreach (AbstractItem item in items.GeneralSearch(Title, Price, Language, Year))
            {
                Items.Add(item);
            }
        }
    }
}


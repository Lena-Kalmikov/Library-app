using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Collections.ObjectModel;

namespace WpfLibrary.ViewModel
{
    public class SearchAudioBookViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand SearchItemCommand { get; set; }
        public RelayCommand OnWindowLoaded { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string NarratedBy { get; set; }
        public double Price { get; set; }
        public LanguageType Language { get; set; }
        public GenreType Genre { get; set; }
        public int Year { get; set; }

        /* Since each type has it's own unique parameters, I wanted the user to see them in a table,
           and not only the basic parameters that are in AbstractItem.
           For example, Book has Genre and Author while AbstractItem does not.
           Journal has Publiser and Edition and Topic, Audiobook has 'Narrated by'.
           For this reason I created 3 Observable Collections - the user can see all the information.
           The search itself is done on AbstractItem List */
        public ObservableCollection<AudioBook> AudioBooks { get; set; }

        public SearchAudioBookViewModel()
        {
            SearchItemCommand = new RelayCommand(Search);
            AudioBooks = new ObservableCollection<AudioBook>();
        }

        public void Search()
        {
            AudioBooks.Clear();

            foreach (AbstractItem item in items.SearchAudioBook(Title, Author, Price, Language, Year, Genre, NarratedBy))
            {
                AudioBook audioBook = (AudioBook)item;
                audioBook.AudioBookPrice = audioBook.GetPrice();
                AudioBooks.Add(audioBook);
            }
        }
    }
}

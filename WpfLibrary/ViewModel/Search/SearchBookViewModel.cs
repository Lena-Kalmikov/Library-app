using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Collections.ObjectModel;

namespace WpfLibrary.ViewModel
{
    public class SearchBookViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand SearchItemCommand { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public LanguageType Language { get; set; }
        public GenreType Genre { get; set; }
        public int Year { get; set; }

        /* Since each type has it's own unique parameters, I wanted the user to see them in a table,
           and not only the basic parameters that are in AbstractItem.
           For example, Book has Genre and Author while AbstractItem does not.
           Journal has Publiser and Edition and Topic, Audiobook has 'Barrated by'.
           For this reason I created 3 Observable Collections - the user can see all the information.
           The search itself is done on AbstractItem List */
        public ObservableCollection<Book> Books { get; set; }

        public SearchBookViewModel()
        {
            SearchItemCommand = new RelayCommand(Search);

            Books = new ObservableCollection<Book>();
        }

        public void Search()
        {

            Books.Clear();

            foreach (AbstractItem item in items.SearchBook(Title, Author, Price, Language, Year, Genre))
            {
                Book book = (Book)item;
                book.BookPrice = book.GetPrice();
                Books.Add(book);
            }
        }
    }
}


using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System;
using System.Windows;

namespace WpfLibrary.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand AddBookCommand { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public GenreType Genre { get; set; }
        public LanguageType Language { get; set; }

        public AddBookViewModel()
        {
            AddBookCommand = new RelayCommand(AddBook);
            items.AddItemAction = NotifySuccessMessage;
        }

        public void NotifySuccessMessage() => MessageBox.Show("Book added");

        private void AddBook()
        {
            try
            {
                items.AddBook(Title, Author, Price, Language, Year, Genre);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

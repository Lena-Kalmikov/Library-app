using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System;
using System.Windows;

namespace WpfLibrary.ViewModel
{
    public class AddAudioBookViewModel : ViewModelBase
    {
        readonly ItemsCollection items = ItemsCollection.Instance;
        public RelayCommand AddAudioBookCommand { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string NarratedBy { get; set; }
        public GenreType Genre { get; set; }
        public LanguageType Language { get; set; }

        public AddAudioBookViewModel()
        {
         
            AddAudioBookCommand = new RelayCommand(AddAudioBook);
            items.AddItemAction = NotifySuccessMessage;
        }

        public void NotifySuccessMessage() => MessageBox.Show("AudioBook added");

        private void AddAudioBook()
        {
            try
            {
                items.AddAudiobook(Title, Author, NarratedBy, Price, Language, Year, Genre);
         
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

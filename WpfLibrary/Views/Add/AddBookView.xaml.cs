using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddBookView.xaml
    /// </summary>
    public partial class AddBookView : Window
    {
        public AddBookView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Genre.ItemsSource = Enum.GetValues(typeof(GenreType));
        }
    }
}

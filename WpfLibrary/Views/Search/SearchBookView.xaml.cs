using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for SearchBookView.xaml
    /// </summary>
    public partial class SearchBookView : Window
    {
        public SearchBookView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Genre.ItemsSource = Enum.GetValues(typeof(GenreType));
        }
    }
}

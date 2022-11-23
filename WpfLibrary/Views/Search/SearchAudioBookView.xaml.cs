using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for SearchAudioBookView.xaml
    /// </summary>
    public partial class SearchAudioBookView : Window
    {
        public SearchAudioBookView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Genre.ItemsSource = Enum.GetValues(typeof(GenreType));
        }
    }
}

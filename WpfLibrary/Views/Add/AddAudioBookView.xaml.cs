using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddAudioBookView.xaml
    /// </summary>
    public partial class AddAudioBookView : Window
    {
        public AddAudioBookView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Genre.ItemsSource = Enum.GetValues(typeof(GenreType));
        }
    }
}

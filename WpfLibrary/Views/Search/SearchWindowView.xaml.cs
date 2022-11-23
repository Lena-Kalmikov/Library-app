using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindowView : Window
    {
        public SearchWindowView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
        }
    }
}

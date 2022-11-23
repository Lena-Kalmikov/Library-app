using BookLib;
using System;
using System.Windows;
using WpfLibrary.Views;

namespace WpfLibrary
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            SearchItemtype.ItemsSource = Enum.GetValues(typeof(ItemType));
            AddItepmType.ItemsSource = Enum.GetValues(typeof(ItemType));
        }

        private void OpenGeneralSearchWindow(object sender, RoutedEventArgs e)
        {
            var win = new SearchWindowView();
            win.Show();
        }

        private void OpenSearchByTypeWindow(object sender, RoutedEventArgs e)
        {

            if (SearchItemtype.SelectedItem != null && SearchItemtype.SelectedItem.ToString() == ItemType.Book.ToString())
            {
                var win = new SearchBookView();
                win.Show();
            }

            if (SearchItemtype.SelectedItem != null && SearchItemtype.SelectedItem.ToString() == ItemType.AudioBook.ToString())
            {
                var win = new SearchAudioBookView();
                win.Show();
            }

            if (SearchItemtype.SelectedItem != null && SearchItemtype.SelectedItem.ToString() == ItemType.Journal.ToString())
            {
                var win = new SearchJournalView();
                win.Show();
            }

        }

        private void OpenAddItemWindow(object sender, RoutedEventArgs e)
        {
            if (AddItepmType.SelectedItem != null && AddItepmType.SelectedItem.ToString() == ItemType.Book.ToString())
            {
                var win = new AddBookView();
                win.Show();
            }

            if (AddItepmType.SelectedItem != null && AddItepmType.SelectedItem.ToString() == ItemType.AudioBook.ToString())
            {
                var win = new AddAudioBookView();
                win.Show();
            }

            if (AddItepmType.SelectedItem != null && AddItepmType.SelectedItem.ToString() == ItemType.Journal.ToString())
            {
                var win = new AddJournalView();
                win.Show();
            }

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

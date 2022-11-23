using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for SearchJournalView.xaml
    /// </summary>
    public partial class SearchJournalView : Window
    {
        public SearchJournalView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Topic.ItemsSource = Enum.GetValues(typeof(TopicType));
            Month.ItemsSource = Enum.GetValues(typeof(MonthType));
        }
    }
}

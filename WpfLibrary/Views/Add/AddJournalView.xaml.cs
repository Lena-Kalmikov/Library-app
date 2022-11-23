using BookLib;
using System;
using System.Windows;

namespace WpfLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddJournalView.xaml
    /// </summary>
    public partial class AddJournalView : Window
    {
        public AddJournalView()
        {
            InitializeComponent();

            Language.ItemsSource = Enum.GetValues(typeof(LanguageType));
            Topic.ItemsSource = Enum.GetValues(typeof(TopicType));
            Month.ItemsSource = Enum.GetValues(typeof(MonthType));
        }
    }
}

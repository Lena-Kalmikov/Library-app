using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace WpfLibrary.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            
            SimpleIoc.Default.Register<GeneralSearchViewModel>();
            SimpleIoc.Default.Register<SearchBookViewModel>();
            SimpleIoc.Default.Register<SearchAudioBookViewModel>();
            SimpleIoc.Default.Register<SearchJournalViewModel>();

            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<AddAudioBookViewModel>();
            SimpleIoc.Default.Register<AddJournalViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        
        public GeneralSearchViewModel GeneralSearch => ServiceLocator.Current.GetInstance<GeneralSearchViewModel>();
        public SearchBookViewModel SearchBook => ServiceLocator.Current.GetInstance<SearchBookViewModel>();
        public SearchAudioBookViewModel SearchAudioBook => ServiceLocator.Current.GetInstance<SearchAudioBookViewModel>();
        public SearchJournalViewModel SearchJournal => ServiceLocator.Current.GetInstance<SearchJournalViewModel>();
        
        public AddBookViewModel AddBook => ServiceLocator.Current.GetInstance<AddBookViewModel>();
        public AddAudioBookViewModel AddAudioBook => ServiceLocator.Current.GetInstance<AddAudioBookViewModel>();
        public AddJournalViewModel AddJournal => ServiceLocator.Current.GetInstance<AddJournalViewModel>();
    }
}
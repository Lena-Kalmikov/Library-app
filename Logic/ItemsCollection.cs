using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ItemsCollection
    {

        int IdCounter = 0;
        public List<AbstractItem> Items { get; set; }
        public Action AddItemAction { get; set; }
        public Action<AbstractItem> SearchItemAction { get; set; }
        public ItemsCollection() => SetData();

        /// <summary>
        /// This gives an id to the items in the list based on their added place in the list.
        /// for example = 5th item will have id #5.
        /// </summary>
        /// <returns>an updated idcounter which give each item in the list a unique id</returns>
        public int GetNextItemID()
        {
            return ++IdCounter;
        }

        /// <summary>
        /// A Function that adds a book to itemscollection.
        /// It can take all parameters that a book can take.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <exception cref="Exception">Since books have 3 mandatory fields, if the user won't provide for them, there will be an exception thrown.</exception>
        public void AddBook(string title, string author, double price, LanguageType language, int year, GenreType genre)
        {
            // title is manadtory
            if (string.IsNullOrEmpty(title))
                throw new Exception("Book must contain a title!");

            // author is manadtory
            if (string.IsNullOrEmpty(author))
                throw new Exception("Book must contain an author!");

            // price can't be zero or lower
            if (price <= 0)
                throw new Exception("Price has to be a positive number!");

            // year rice can't be zero or lower
            if (year <= 0)
                throw new Exception("Year has to be a positive number!");

            AbstractItem item = new Book(title, author, price, this.GetNextItemID(), year, language, genre);
            this.AddItem(item);
        }

        /// <summary>
        /// A Function that adds a journal to itemscollection.
        /// It can take all parameters that a bojournalok can take.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="publisher"></param>
        /// <param name="price"></param>
        /// <param name="edition"></param>
        /// <param name="language"></param>
        /// <param name="topic"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <exception cref="Exception">Since journals have 3 mandatory fields, if the user won't provide for them, there will be an exception thrown</exception>
        public void AddJournal(string title, string publisher, double price, int edition, LanguageType language, TopicType topic, int year, MonthType month)
        {
            // title is manadtory
            if (string.IsNullOrEmpty(title))
                throw new Exception("Journal must contain a title!");

            // publisher is manadtory
            if (string.IsNullOrEmpty(publisher))
                throw new Exception("Journal must contain a publisher!");

            // price can't be zero or lower
            if (price <= 0)
                throw new Exception("Price has to be a positive number!");

            // year rice can't be zero or lower
            if (year <= 0)
                throw new Exception("Year has to be a positive number!");

            // edition rice can't be zero or lower
            if (edition <= 0)
                throw new Exception("Edition has to be a positive number!");

            AbstractItem item = new Journal(title, publisher, price, edition, this.GetNextItemID(), year, language, topic, month);
            this.AddItem(item);
        }

        /// <summary>
        /// A Function that adds an audiobook to itemscollection.
        /// It can take all parameters that a book can take.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="narratedBy"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <exception cref="Exception">Since audiobook have 4 mandatory fields, if the user won't provide for them, there will be an exception thrown</exception>
        public void AddAudiobook(string title, string author, string narratedBy, double price, LanguageType language, int year, GenreType genre)
        {
            // title is manadtory
            if (string.IsNullOrEmpty(title))
                throw new Exception("Audiobook must contain a title!");

            // author is manadtory
            if (string.IsNullOrEmpty(author))
                throw new Exception("Audiobook must contain an author!");

            // narrator is manadtory
            if (string.IsNullOrEmpty(narratedBy))
                throw new Exception("Audiobook must contain a Narrator!");

            // price can't be zero or lower
            if (price <= 0)
                throw new Exception("Price has to be a positive number!");

            // year rice can't be zero or lower
            if (year <= 0)
                throw new Exception("Year has to be a positive number!");

            AbstractItem item = new AudioBook(title, author, price, this.GetNextItemID(), year, language, genre, narratedBy);
            this.AddItem(item);
        }

        /// <summary>
        /// this method adds an item to the list.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(AbstractItem item)
        {
            Items.Add(item);            
            if (AddItemAction != null)
                AddItemAction();
        }

        /// <summary>
        /// A general search method that checks and includes all possible parameters for all item types, 
        /// and then each specific search function uses the parameters it needs. 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <param name="publisher"></param>
        /// <param name="edition"></param>
        /// <param name="month"></param>
        /// <param name="narratedBy"></param>
        /// <param name="topic"></param>
        /// <param name="ItemType"></param>
        /// <returns>A list of values that match the search parameters.</returns>
        public IEnumerable<AbstractItem> SearchItem(string title, string author, double price, LanguageType language, int year, GenreType genre,
                                                    string publisher, int edition, MonthType month, string narratedBy, TopicType topic, ItemType ItemType)
        {
            return Items.Where(item =>
           {
               return
                  (string.IsNullOrEmpty(title) || item.Title.ToLower().Contains(title.ToLower()))
               && (string.IsNullOrEmpty(author) || (item is Book && ((Book)item).Author.ToLower().Contains(author.ToLower())))
               && (price <= 0 || price == item.Price)
               && (language == LanguageType.None || item.Language == language)
               && (year <= 0 || year == item.PublicationYear)
               && (genre == GenreType.None || (item is Book && ((Book)item).Genre == genre))
               && (string.IsNullOrEmpty(publisher) || item.Title.ToLower() == publisher.ToLower())
               && (edition <= 0 || (item is Journal && ((Journal)item).Edition == edition))
               && (month == MonthType.None || (item is Journal && ((Journal)item).Month == month))
               && (string.IsNullOrEmpty(narratedBy) || (item is AudioBook && ((AudioBook)item).NarratedBy.ToLower().Contains(narratedBy.ToLower())))
               && (topic == TopicType.None || (item is Journal && ((Journal)item).Topic == topic))
               && (ItemType == ItemType.None || ItemType == item.ItemType);
           });
        }

        // these 3 specific search methods use the parameters they need for specific item type from the general search function.
        /// <summary>
        /// This method searches all items by the 4 parameters included in abstract item.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<AbstractItem> GeneralSearch(string title = null, double price = 0, LanguageType language = LanguageType.None, int year = 0)
            => this.SearchItem(title, null, price, language, year, GenreType.None, null, 0, MonthType.None, null, TopicType.None, ItemType.None);

        /// <summary>
        /// This search method searches books by it's parameters.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public IEnumerable<AbstractItem> SearchBook(string title = null, string author = null, double price = 0, LanguageType language = LanguageType.None, 
                                                    int year = 0, GenreType genre = GenreType.None)
            => this.SearchItem(title, author, price, language, year, genre, null, 0, MonthType.None, null, TopicType.None, ItemType.Book);

        /// <summary>
        /// This search method searches audiobooks by it's parameters.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <param name="narratedBy"></param>
        /// <returns></returns>
        public IEnumerable<AbstractItem> SearchAudioBook(string title = null, string author = null, double price = 0, LanguageType language = LanguageType.None, 
                                                         int year = 0, GenreType genre = GenreType.None, string narratedBy = null)
            => this.SearchItem(title, author, price, language, year, genre, null, 0, MonthType.None, narratedBy, TopicType.None, ItemType.AudioBook);

        /// <summary>
        /// This search method searches journals by it's parameters.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="publisher"></param>
        /// <param name="price"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="topic"></param>
        /// <param name="edition"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<AbstractItem> SearchJournal(string title = null, string publisher = null, double price  =0, LanguageType language = LanguageType.None,
                                                       int year = 0, TopicType topic = TopicType.None, int edition = 0, MonthType month = MonthType.None)
            => this.SearchItem(title, null, price, language, year, GenreType.None, publisher, edition, month, null, topic, ItemType.Journal);


        /// <summary>
        /// Adds initial list of items to collection
        /// </summary>
        public void SetData()
        {
            Items = new List<AbstractItem>();

            Items.Add(new Book("The Fellowship of the Ring", "J.R.R Tolkien", 9.99, this.GetNextItemID(), 1970, LanguageType.English, GenreType.Fantasy));
            Items.Add(new AudioBook("Game of Thrones", "George R.R Martin", 12.00, this.GetNextItemID(), 1996, LanguageType.English, GenreType.Fantasy, "Stephen Fry"));
            Items.Add(new Book("Metamorphoses", "Ovid", 29.00, this.GetNextItemID(), 1912, LanguageType.Latin, GenreType.EpicPoetry));
            Items.Add(new Book("Odyssey", "Homer", 55.5, this.GetNextItemID(), 1926, LanguageType.AnciantGreek, GenreType.EpicPoetry));
            Items.Add(new Book("The Trial", "Franz Kafka", 30.00, this.GetNextItemID(), 1818, LanguageType.German, GenreType.Drama));
            Items.Add(new Journal("Le Medicine", "BMJ Med", 2.50, 4, this.GetNextItemID(), 2020, LanguageType.French, TopicType.Medicine, MonthType.May));
            Items.Add(new Journal("National Geographic", "NTG", 12.50, 14, this.GetNextItemID(), 2021, LanguageType.English, TopicType.Nature, MonthType.February));
            Items.Add(new AudioBook("Call of the Wild", "Jack London", 15.5, this.GetNextItemID(), 1890, LanguageType.English, GenreType.Adventure, "White Fang"));
            Items.Add(new Book("Romeo and Juliet", "Shakespeare", 8.00, this.GetNextItemID(), 1815, LanguageType.English, GenreType.Tragedy));
            Items.Add(new Book("One Thousand and One Nights", "Various", 21.99, this.GetNextItemID(), 1940, LanguageType.Arabic, GenreType.FolkTales));
        }
        
        /// <summary>
        /// This allows the user to search books by ISBN, which is a sequence of characters and numbers
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book this[string isbn] => (Book)Items.Where(item =>
        {
            return item is Book && ((Book)item).ISBN == isbn;

        }).FirstOrDefault();
        
        /// <summary>
        /// check the list by it's item type (book/kournal/audiobook)
        /// </summary>
        /// <param name="items"></param>
        /// <param name="type"></param>
        /// <returns>a list of items by requested type</returns>
        public IEnumerable<AbstractItem> GetItemByType(IEnumerable<AbstractItem> items, string type)
        {
            return items.Where(item => item.GetType().Name == type);
        }

        #region Singleton
        private static ItemsCollection instance;
        public static ItemsCollection Instance => instance ?? (instance = new ItemsCollection());
        #endregion
    }
}


using BookLib;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTests
    {
        readonly ItemsCollection collection = new ItemsCollection();

        public void InitTestData()
        {
            collection.SetData();
        }


        [TestMethod]
        public void AddItemTest()
        {
            int count = collection.Items.Count;
            collection.AddItem(new Book("testTitle", "testAuthor", 99, 22, 1990));
            Assert.IsTrue(collection.Items.Count == count + 1);
        }

        [TestMethod]
        public void SearchBook()
        {
            InitTestData();

            foreach (AbstractItem item in collection.SearchBook("Metamorphoses"))
            {
                Assert.IsTrue(item is Book && item.Title == "Metamorphoses");
            }
        }

        [TestMethod]
        public void SearchAudioBook()
        {
            InitTestData();

            foreach (AbstractItem item in collection.SearchAudioBook(null, null, 0, LanguageType.None, 1996))
            {
                Assert.IsTrue(item is AudioBook && item.PublicationYear == 1996);
            }
        }

        [TestMethod]
        public void SearchJournal()
        {
            InitTestData();

            foreach (Journal item in collection.SearchJournal(null, null, 0, LanguageType.None, 0, TopicType.Nature))
            {
                Assert.IsTrue(item.Topic == TopicType.Nature);
            }
        }

        [TestMethod]
        public void TestGetPrice()
        {
            // there's no discount on Fantasy Genre, so the result is expected to be false.
            Book book = new Book(null, null, 100, 0, 0, LanguageType.None,GenreType.Fantasy);
            Assert.IsFalse(book.GetPrice() == 70);
        }


        [TestMethod]
        public void GetNextItemID()
        {
            int count = collection.Items.Count;
            int id = collection.GetNextItemID();
            Assert.IsTrue(id == (count + 1));
        }

        [TestMethod]
        public void ISBNIndexerTest()
        {
            InitTestData();
            Book book = new Book("testTitle", "J.R.R Tolkien", 100, 0, 0);
            string ISBN = "test";
            book.ISBN = ISBN;
            collection.Items.Add(book);

            Book newBook = collection[ISBN];

            Assert.IsTrue(newBook.ISBN == ISBN);

        }
    }
}

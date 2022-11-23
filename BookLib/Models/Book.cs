using System;

namespace BookLib
{
    public partial class Book : AbstractItem
    {
        public GenreType Genre { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double BookPrice { get; set; }
       
        public override double GetPrice()
        {
            if (Genre == GenreType.EpicPoetry)
                return 0.7 * base.GetPrice();

            if (Price < 10.00)
                return 0.9 * base.GetPrice();

            else return base.GetPrice();
        }

        public Book
        (
            string title,
            string author,
            double price,
            int id,
            int publicationYear,
            LanguageType language = LanguageType.None,
            GenreType genre = GenreType.None,
            ItemType itemType = ItemType.Book
        )
            : base(title, price, publicationYear, language, id, itemType)
        {
            Genre = genre;
            Author = author;
            ISBN = Guid.NewGuid().ToString();
        }
    }
}

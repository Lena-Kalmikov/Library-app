namespace BookLib
{
    public class AudioBook : Book
    {
        public string NarratedBy { get; set; }
        public double AudioBookPrice { get; set; }
        public override double GetPrice() => 0.9 * base.GetPrice();

        public AudioBook 
        (
            string title,
            string author,
            double price,
            int id,
            int publicationYear,
            LanguageType language = LanguageType.None,
            GenreType genre = GenreType.None,
            string narratedBy="",
            ItemType itemType = ItemType.AudioBook

        )
            : base(title, author, price, id, publicationYear, language, genre, itemType)
        {
            NarratedBy = narratedBy;
        }
    }
}

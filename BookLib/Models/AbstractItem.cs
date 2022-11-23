namespace BookLib
{
    public abstract partial class AbstractItem : IPriceable
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public int PublicationYear { get; set; }
        public LanguageType Language { get; set; }
        public ItemType ItemType { get; set; }
        public virtual double GetPrice() => Price;

        public AbstractItem (string title, double price, int publicationYear, LanguageType language, int id, ItemType itemType)
        {
            Title = title;
            Price = price;
            Language = language;
            PublicationYear = publicationYear;
            Id = id;
            ItemType = itemType;
        }
    }
}

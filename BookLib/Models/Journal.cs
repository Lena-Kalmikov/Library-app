namespace BookLib
{
    public partial class Journal : AbstractItem
    {
        public TopicType Topic { get; set; }
        public MonthType Month { get; set; }
        public string Publisher { get; set; }
        public int Edition { get; set; }
        public double JournalPrice { get; set; }

        public override double GetPrice()
        {
            if (Topic == TopicType.ComputerScience)
                return 7 * base.GetPrice();

            if (Month == MonthType.May)
                return 0.75 * base.GetPrice();

            if (Publisher == "NTG")
                return 0.95 * base.GetPrice();

            else return base.GetPrice();
        }
        public Journal
        (
            string title,
            string publisher,
            double price,
            int edition,
            int id,
            int publicationYear,
            LanguageType language = LanguageType.None,
            TopicType topic = TopicType.None,
            MonthType month = MonthType.None,
            ItemType itemType = ItemType.Journal
        )
            : base(title, price, publicationYear, language, id, itemType)
        {
            Publisher = publisher;
            Edition = edition;
            Topic = topic;
            Month = month;
        }
    }
}

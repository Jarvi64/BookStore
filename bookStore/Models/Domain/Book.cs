namespace bookStore.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorID { get; set; }   
        public Guid PublisherID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public int PublicationYear { get; set; }
        public int StockLevel { get; set; }
        public decimal Price { get; set; }

        //Navigation properites
        public virtual Publisher Publisher { get; set; }
        public virtual Author Author { get; set; }
    }
}

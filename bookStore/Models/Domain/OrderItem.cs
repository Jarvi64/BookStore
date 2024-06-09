namespace bookStore.Models.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderID { get; set; }
        public Guid BookID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}

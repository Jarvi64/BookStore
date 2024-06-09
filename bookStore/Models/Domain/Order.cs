    namespace bookStore.Models.Domain
    {
        public class Order
        {
            public Guid Id { get; set; }
            public string CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal Subtotal { get; set; }
            public decimal Shipping { get; set; }
            public decimal Total { get; set; }
            public virtual Customer Customer { get; set; }
            public virtual ICollection<OrderItem> OrderItems { get; set; }
        }
    }

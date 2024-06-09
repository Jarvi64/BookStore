using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderCreateDto
    {
        [Required(ErrorMessage = "CustomerID is required")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "OrderDate is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Subtotal must be a non-negative value")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Shipping is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Shipping must be a non-negative value")]
        public decimal Shipping { get; set; }

        [Required(ErrorMessage = "Total is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a non-negative value")]
        public decimal Total { get; set; }
    }

    public class OrderUpdateDto
    {
        [Required(ErrorMessage = "CustomerID is required")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "OrderDate is required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Subtotal must be a non-negative value")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Shipping is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Shipping must be a non-negative value")]
        public decimal Shipping { get; set; }

        [Required(ErrorMessage = "Total is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a non-negative value")]
        public decimal Total { get; set; }
    }
}

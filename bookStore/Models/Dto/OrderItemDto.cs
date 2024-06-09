using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid BookID { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderItemCreateDto
    {
        [Required(ErrorMessage = "BookID is required")]
        public Guid BookID { get; set; }

        [Required(ErrorMessage = "OrderID is required")]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }
    }

    public class OrderItemUpdateDto
    {
        [Required(ErrorMessage = "BookID is required")]
        public Guid BookID { get; set; }

        [Required(ErrorMessage = "OrderID is required")]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public decimal Price { get; set; }
    }
}

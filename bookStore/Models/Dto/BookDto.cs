using System;
using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public int PublicationYear { get; set; }
        public int StockLevel { get; set; }
        public decimal Price { get; set; }
    }

    public class BookCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1,7}", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre can't be longer than 50 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type can't be longer than 50 characters")]
        public string Type { get; set; }

        [Range(1450, 2100, ErrorMessage = "Publication Year must be between 1450 and 2100")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock Level must be a non-negative value")]
        public int StockLevel { get; set; }

        [Required(ErrorMessage = "AuthorId is required")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "PublisherId is required")]
        public Guid PublisherId { get; set; }
    }

    public class BookUpdateDto
    {
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [RegularExpression(@"\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1,7}", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }

        [StringLength(50, ErrorMessage = "Genre can't be longer than 50 characters")]
        public string Genre { get; set; }

        [StringLength(50, ErrorMessage = "Type can't be longer than 50 characters")]
        public string Type { get; set; }

        [Range(1450, 2100, ErrorMessage = "Publication Year must be between 1450 and 2100")]
        public int PublicationYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock Level must be a non-negative value")]
        public int StockLevel { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        public Guid AuthorId { get; set; }

        public Guid PublisherId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    public class PublisherDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Country { get; set; }
    }

    public class PublisherCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        public string Email { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [StringLength(100, ErrorMessage = "Website URL can't be longer than 100 characters")]
        public string WebSite { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country can't be longer than 100 characters")]
        public string Country { get; set; }
    }

    public class PublisherUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        public string Email { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [StringLength(100, ErrorMessage = "Website URL can't be longer than 100 characters")]
        public string WebSite { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100, ErrorMessage = "Country can't be longer than 100 characters")]
        public string Country { get; set; }
    }
}

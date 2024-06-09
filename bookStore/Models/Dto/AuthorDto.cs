using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    
        public class AuthorDto
        {
            public Guid Id { get; set; }
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
        public List<BookDto> Books { get; set; }
    }

    public class AuthorCreateDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
        public string LastName { get; set; }
    }

    public class AuthorUpdateDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
        public string LastName { get; set; }
    }
}


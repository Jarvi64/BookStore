using System.ComponentModel.DataAnnotations;

namespace bookStore.Models.Dto
{
    public class CustomerDto
    {
    }
    public class RegisterCustomerDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        //[Required]
        //public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Country { get; set; }
    }

    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginResponceDto
    {
        public string Jwt { get; set; }
    }
}
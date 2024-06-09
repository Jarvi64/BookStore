using Microsoft.AspNetCore.Identity;

namespace bookStore.Models.Domain
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

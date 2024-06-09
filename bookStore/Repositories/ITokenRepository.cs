using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(Customer user);
    }
}

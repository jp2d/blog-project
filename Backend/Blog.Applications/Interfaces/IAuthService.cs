using Blog.Domain.Entity;

namespace Blog.Applications.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
        Task<User?> GetUserByEmail(string email);
    }
}

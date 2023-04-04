using Poliza.Models;

namespace Poliza.Repositories.Interfaces
{
    public interface ILoginRepository
    {
       Task<UserEntity> GetUser(string username, string password);
    }
}

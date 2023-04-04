using Microsoft.EntityFrameworkCore;
using Poliza.Models;
using Poliza.Repositories.Interfaces;

namespace Poliza.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly PolicyContextEntity _context;

        public LoginRepository(PolicyContextEntity context)
        {
            _context = context;
        }
        public LoginRepository()
        {
        }
        public async Task<UserEntity> GetUser(string name, string password)
        {
            try
            {
                return await _context.UsersItems.SingleOrDefaultAsync(u => u.Name == name && u.Password == password);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

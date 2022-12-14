using TPI_Programación3.Entities;
using TPI_Programación3.Models;

namespace TPI_Programación3.Repository
{
    public interface IUserRepository
    {
        public User? GetOne(int id);

        public List<User> GetAll();

        public void Add(User user);

        public void Delete(int id);

        public void Edit(int id, string newPassword);
        public User? ValidateUser(AuthRequest user);
    }
}

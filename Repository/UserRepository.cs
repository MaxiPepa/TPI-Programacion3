using TPI_Programación3.DBContext;
using TPI_Programación3.Entities;
using TPI_Programación3.Helpers;
using TPI_Programación3.Models;

namespace TPI_Programación3.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TridentExchangeDBContext _context;

        public UserRepository(TridentExchangeDBContext context)
        {
            _context = context;
        }


        public User? GetOne(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }catch
            {

            }
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.First(x => x.Id == id));
        }

        public void Edit(int id, string newPassword)
        {
            _context.Users.First(x => x.Id == id).Password = newPassword;
        }

        public User? ValidateUser(AuthRequest dto)
        {
            var pass = Security.CreateSHA512(dto.Password);
            return _context.Users.SingleOrDefault(u => u.FullName == dto.FullName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}

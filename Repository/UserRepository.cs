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
            try
            {
                return _context.Users.First(x => x.Id == id);
            }
            catch
            {
                throw new Exception("User not found");
            }
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
            } 
            catch
            {
                throw new Exception("Error in the user adding or invalid parameters");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Users.Remove(_context.Users.First(x => x.Id == id));
                _context.SaveChanges();
            } 
            catch
            {
                throw new Exception("User not found");
            }
        }

        public void Edit(int id, string newPassword)
        {
            try
            {
                _context.Users.First(x => x.Id == id).Password = newPassword;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("User not found or invalid parameters");
            }
        }

        public User? ValidateUser(AuthRequest dto)
        {
            var pass = Security.CreateSHA512(dto.Password);
            return _context.Users.SingleOrDefault(u => u.FullName == dto.FullName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}

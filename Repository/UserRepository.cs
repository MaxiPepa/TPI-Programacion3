﻿using TPI_Programación3.Entities;
using TPI_Programación3.Helpers;
using TPI_Programación3.Models;

namespace TPI_Programación3.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> storedUsers = new()
        {
            new User(1, "Alejo", "alejo@gmail.com", "123", "Common"),
            new User(2, "Gaston", "gaston_elcapo@gmail.com", "abc", "Common"),
            new User(3, "Maxi", "elmassi@gmail.com", "789", "Common"),
            new User(4, "Milton", "milton_tucson_tuki@gmail.com", "qwe", "Administrator"),
            new User(5, "Pedro", "pedrito@gmail.com", "cxz", "Administrator"),
        };

        public User? GetOne(int id)
        {
            return storedUsers.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return storedUsers;
        }

        public void Add(User user)
        {
            storedUsers.Add(user);
        }

        public void Delete(int id)
        {
            storedUsers.Remove(storedUsers.First(x => x.Id == id));
        }

        public void Edit(int id, string newPassword)
        {
            storedUsers.First(x => x.Id == id).Password = newPassword;
        }

        public User? ValidateUser(AuthRequest dto)
        {
            return storedUsers.SingleOrDefault(u => u.FullName == dto.FullName && u.Password == Security.CreateSHA512(dto.Password));
        }
    }
}

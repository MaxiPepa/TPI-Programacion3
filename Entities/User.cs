namespace TPI_Programación3.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int id ,string fullName, string email, string password, string role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

    }
}
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

        public string LoadUser()
        {
            return Enums.Role.Administrator.ToString();
        }

        public void ChangeName()
        {

        }

        public void ChangePassword()
        {

        }

        public void DeleteOffer()
        {

        }

        public void BanUser()
        {

        }

    }
}
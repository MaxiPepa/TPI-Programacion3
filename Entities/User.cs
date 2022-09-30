namespace TPI_Programación3.Entities
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

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

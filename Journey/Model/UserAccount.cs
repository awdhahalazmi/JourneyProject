
using BCrypt.Net;

namespace Journy.Model
{
    public class UserAccount
    {

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string ImagePath { get; set; }

        public List<UserAccount> Followers { get; set; }
        public List<UserAccount> Following { get; set; }
        public bool IsAdmin { get; set; }
       private UserAccount() { }

        public static UserAccount Create(string username, string password, bool isAdmin = false)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA384);
                return new UserAccount
                {
                    Username = username,
                    Password = hashedPassword,
                    IsAdmin = isAdmin
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error hashing password: {ex.Message}");
                throw;
            }
        }




        public bool VerifyPassword(string pwd) => BCrypt.Net.BCrypt.EnhancedVerify(pwd, this.Password);
    }



}

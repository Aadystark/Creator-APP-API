using LearningAPI.Repository;

namespace LearningAPI.Services
{
    public class UserService : IUser
    {
        public UserService() { }

        public List<Users.Users> user = new List<Users.Users>() {
        new Users.Users()
        {
            Id= 1,
            UserName = "aadi",
            Email = "aadistark2000@gmail.com",
            Password = "aa221100",
            Roles = new List<string>(){"user", "admin" }
        },
         new Users.Users()
        {
            Id= 2,
            UserName = "bushido",
            Email = "bushido@gmail.com",
            Password = "bb221100",
            Roles = new List<string>(){"user"}
        }
        };
        public async Task<Users.Users> AuthenticateUser(string username, string password)
        {
            var users = user.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password));
            return users;
        }
    }
}

namespace LearningAPI.Repository
{
    public interface IUser
    {
        public Task<Users.Users> AuthenticateUser(string username, string password);
    }
}

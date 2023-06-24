using System.Runtime.InteropServices;

namespace LearningAPI.Repository
{
    public interface IToken
    {
      Task<string> CreateToken(Users.Users user);
    }
}

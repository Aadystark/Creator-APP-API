using LearningAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LearningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUser user;
        private readonly IToken token;
        public AuthController(IUser user, IToken token)
        {
            this.user = user;
            this.token = token;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(DTO.LoginDTO login)
        {
            var auth = await user.AuthenticateUser(
                login.UserName, login.Password);
            if (auth != null)
            {
                var tokens = await token.CreateToken(auth);
                return Ok(tokens.ToString());
            }
            return BadRequest("Username or Pass Incorrect!");
            
        }
    }
}

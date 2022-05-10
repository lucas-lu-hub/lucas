using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using static MyWebAPI.Auth.JWTHelper;

namespace MyWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public string Login(string name, string password)
        {
            if (name == "admin" && password == "xA123456")
            {
                var token = JwtHelper.IssueJwt(new TokenModelJwt
                {
                    Uid = Guid.NewGuid(),
                    Role = "aaa",
                    Work = "manager"
                });
                return token;
            }

            return string.Empty;
        }
    }
}

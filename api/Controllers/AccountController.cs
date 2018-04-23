using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using covalisage.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace covalisage.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager , SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Credential credential)
        {
            var user = new User{ Email = credential.email, UserName = credential.email};
            var result = await userManager.CreateAsync(user, credential.password);
            if(!result.Succeeded)
             return BadRequest(result.Errors);
            await signInManager.SignInAsync(user , isPersistent:false);
            return Ok(createToken(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Credential credential)
        {
            var result = await signInManager.PasswordSignInAsync(credential.email , credential.password, false , false);
            if(!result.Succeeded)
             return BadRequest();
            var user = await userManager.FindByEmailAsync(credential.email);
            return Ok(createToken(user));
        }

        string createToken(User user)
        {
            var claims = new Claim[]
            {
               new Claim(JwtRegisteredClaimNames.Sub , user.Id) 
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret phrase"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new  JwtSecurityToken(signingCredentials: signingCredentials, claims:claims);
            return  new JwtSecurityTokenHandler().WriteToken(jwt); 
        }
    }
}
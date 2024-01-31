using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocalFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClubController : Controller
    {
        private readonly IUserService _IUserService;
        public readonly IConfiguration _configuration;
        public ClubController(IUserService UserService, IConfiguration configuration)
        {
            _IUserService = UserService;    
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult AddClub([FromBody] LoginRequest request)
        {
            try
            {

                LoginResponse Response = new LoginResponse();
                var data = _IUserService.Authenticate(request);

                if (data != null)
                {
                    var issuer = _configuration.GetValue<string>("Jwt:Issuer");
                    var audience = _configuration.GetValue<string>("Jwt:Audience");
                    var key = Encoding.ASCII.GetBytes
                    (_configuration.GetValue<string>("Jwt:Key"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                        new Claim("id", data.name),
                        new Claim(JwtRegisteredClaimNames.Name, string.Format("{0}", data.name)),
                        new Claim(JwtRegisteredClaimNames.Email, data.email),
                        new Claim(JwtRegisteredClaimNames.Jti, JsonConvert.SerializeObject(data))
                    }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    Response.id = data.id;
                    Response.name = data.name;
                    Response.email = data.email;
                    Response.phone = data.phone;
                    Response.email = data.email;
                    Response.password = data.password;
                    Response.address = data.address;
                    Response.status = data.status;
                    Response.role = data.role;
                    Response.gender = data.gender;
                    Response.registrationdate = data.registrationdate;
                    Response.updatedby = data.updatedby;
                    Response.updateddate = data.updateddate;
                    Response.company = data.company;
                    Response.token = jwtToken;
                    return Ok(Response);
                }
                else
                {
                    return RedirectToAction("Login");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

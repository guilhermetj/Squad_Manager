using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Squad_Manager.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AuthController :Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        
        public AuthController(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost(), AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserLoginDto loginDto)
        {
            var userBanco = await _repository.GetByEmail(loginDto.Email);
            if (userBanco == null)
                return NotFound("User not found");
            if (loginDto.Password != userBanco.Password)
                return NotFound("Password invalid");

            string token = CreateToken(userBanco);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

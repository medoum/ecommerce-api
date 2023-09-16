using AutoMapper;
using EcommerceApi.Abstract;
using EcommerceApi.Dto;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtil;

        public AuthController(IAuthService authService, IMapper mapper, IJwtUtils jwtUtils)
        {
            _authService = authService;
            _mapper = mapper;
            _jwtUtil = jwtUtils;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null)
                return BadRequest();

            await _authService.RegisterUser(registerDto);
            

            return Ok(new {
                Message = "Utilisateur inscrit",
           
            });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if(string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest(new { Message = "L'email et le mot de passe sont requis" });
            }

            var user = await _authService.Login(loginDto);

            if (user == null)
            {
             
                return Unauthorized(new { Message = "Mot de passe ou email invalide" });
            }

            // Generate and return a JWT token upon successful authentication


            return Ok(new
            {
                Message = "User logged in successfully",
        
            });
        }
    }
}

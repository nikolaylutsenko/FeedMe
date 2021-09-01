using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IAuthService authService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(AddUserRequest request)
        {
            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var addRoleResult = await _userManager.AddToRoleAsync(user, "user");

            if (!addRoleResult.Succeeded) return BadRequest(addRoleResult.Errors);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return BadRequest("The Email or Password is incorrect");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = _authService.GenerateToken(user.Id, userRoles);
            var result = _mapper.Map<TokenResponse>(token);

            return Ok(result);
        }
    }

    public class TokenResponse
    {
        public string AccessToken { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AddUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
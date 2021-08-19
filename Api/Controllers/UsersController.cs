using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserRequest request)
        {
            var user = new AppUser
            {
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = $"{request.Name}_{request.Surname}",
                NormalizedUserName = $"{request.Name}_{request.Surname}".ToUpper()
            };

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }
    }

    public class AddUserRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
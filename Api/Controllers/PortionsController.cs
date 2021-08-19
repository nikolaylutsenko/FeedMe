using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Request;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortionsController : ControllerBase
    {
        private readonly IService<Portion> _portionService;
        private UserManager<AppUser> _userManager;

        public PortionsController(IService<Portion> portionService)
        {
            _portionService = portionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPotionAsync(AddPotionRequest request)
        {
            // get current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var portion = new Portion
            {
                Weight = request.Weight,
                Date = DateTime.UtcNow,
                UserId = userId
            };

            await _portionService.AddAsync(portion);

            return Ok();
        }
    }
}
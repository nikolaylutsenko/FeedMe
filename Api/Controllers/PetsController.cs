using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Pet> _petService;
        private readonly SignInManager<AppUser> _signInManager;

        public PetsController(IService<Pet> petService, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _petService = petService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentPetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name) ?? StaticValues.AdminUserId;

            var pet = (await _petService.GetAllAsync()).FirstOrDefault(x => x.OwnerId == Guid.Parse(userId));

            if (pet is null) return NotFound();

            var response = _mapper.Map<PetResponse>(pet);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPetAsync(AddPetRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name) ?? StaticValues.AdminUserId;

            var pet = _mapper.Map<Pet>(request);
            pet.OwnerId = Guid.Parse(userId);

            await _petService.AddAsync(pet);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePetAsync(Guid id, UpdatePetRequest request)
        {
            var pet = await _petService.GetAsync(id);

            pet = _mapper.Map(request, pet);

            await _petService.UpdateAsync(pet);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePetAsync(Guid id)
        {
            var pet = await _petService.GetAsync(id);

            if (pet is null) return NotFound();

            await _petService.DeleteAsync(id);

            return NoContent();
        }
    }

    public class PetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }

    public class UpdatePetRequest
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }

    public class AddPetRequest
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Request;
using Response;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Portion> _portionService;

        public PortionsController(IService<Portion> portionService, IMapper mapper)
        {
            _portionService = portionService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPortionAsync(AddPotionRequest request)
        {
            // get current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var portion = new Portion
            {
                Weight = request.Weight,
                Date = DateTime.UtcNow,
                //UserId = Guid.NewGuid()
            };

            await _portionService.AddAsync(portion);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPortionsAsync()
        {
            var portions = (await _portionService.GetAllAsync()).OrderByDescending(x => x.Date);
            var result = _mapper.Map<IEnumerable<PortionResponse>>(portions);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortionByIdAsync(Guid id)
        {
            var portion = await _portionService.GetAsync(id);

            if (portion is null) return BadRequest();

            var result = _mapper.Map<PortionResponse>(portion);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePortionAsync(Guid id, PortionUpdateRequest updateRequest)
        {
            var portion = await _portionService.GetAsync(id);
            _mapper.Map(updateRequest, portion);

            var result = await _portionService.UpdateAsync(portion);

            if (!result) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePortionAsync(Guid id)
        {
            var result = await _portionService.DeleteAsync(id);

            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
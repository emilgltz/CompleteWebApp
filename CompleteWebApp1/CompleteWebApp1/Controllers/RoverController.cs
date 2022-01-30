using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompleteWebApp1.Domain.Models;
using CompleteWebApp1.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CompleteWebApp1.Resources;

namespace CompleteWebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : Controller
    {
        private readonly IRoverService _roverService;
        private readonly IMapper _mapper;

        public RoverController(IRoverService roverService, IMapper mapper)
        {
            _roverService = roverService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoverResource>> GetAllAsync()
        {
            var rover = await _roverService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Rover>, IEnumerable<RoverResource>>(rover);
            return resources;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoverResource>> GetRover(int id)
        {
            var rover = await _roverService.GetRoverByIdAsync(id);
            var resource = _mapper.Map<Rover, RoverResource>(rover);

            if (rover == null)
            {
                return NotFound();
            }

            return resource;
        }
    }
}

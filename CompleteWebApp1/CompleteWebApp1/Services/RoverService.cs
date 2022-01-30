using CompleteWebApp1.Domain.Models;
using CompleteWebApp1.Domain.Repositories;
using CompleteWebApp1.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteWebApp1.Services
{
    public class RoverService : IRoverService
    {
        private readonly IRoverRepository _roverRepository;

        public RoverService(IRoverRepository roverRepository)
        {
            _roverRepository = roverRepository;
        }

        public async Task<Rover> GetRoverByIdAsync(int id)
        {
            return await _roverRepository.GetRoverByIdAsync(id);
        }

        public async Task<IEnumerable<Rover>> ListAsync()
        {
            return await _roverRepository.ListAsync();
        }

    }
}

using CompleteWebApp1.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteWebApp1.Domain.Services
{
    public interface IRoverService
    {
        Task<IEnumerable<Rover>> ListAsync();
        Task<Rover> GetRoverByIdAsync(int id);
    }
}

﻿using CompleteWebApp1.Domain.Models;
using CompleteWebApp1.Domain.Repositories;
using CompleteWebApp1.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteWebApp1.Persistence.Repositories
{
    public class RoverRepository : BaseRepository, IRoverRepository
    {
        public RoverRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Rover> GetRoverByIdAsync(int id)
        {
            IQueryable<Rover> query = _context.Rovers;
            //.Include(r => r.History);

            query = query.Where(r => r.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Rover>> ListAsync()
        {
            return await _context.Rovers.ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;
using breakroutines.Utils;
using Microsoft.EntityFrameworkCore;

namespace breakroutines.Data.Repositoryes
{
    public class TripService : BaseService, ITripService
    {
        public TripService(breakroutinesContext context) : base(context) {}

        public Task<ProcessResult> Add(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<List<Trip>>> GetByCategoty(string category)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessResult<List<Trip>>> GetByNearToMe(decimal latitude, decimal longitude)
        {
            Func<Task<List<Trip>>> action = async () =>
            {
                var trips = await context.Trips.Where(x => x.Latitude == latitude && x.Longitude == longitude).Include(x => x.TripPhotos.Where( tp => tp.IsDefault == true) ).ToListAsync();
                return trips;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<Trip>> GetSingleById(long id)
        {
            Func<Task<Trip>> action = async () =>
            {
                var trips = await context.Trips.Where(x => x.TripId == id).Include(x => x.Reviews).Include(x => x.TripPhotos).FirstOrDefaultAsync();
                return trips;
            };

            return await Process.RunAsync(action);
            
        }

        public Task<ProcessResult> Update(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}

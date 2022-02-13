using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;

namespace breakroutines.Data.Repositoryes
{
    public class TripRepository : BaseService, ITripRepository
    {
        public TripRepository(breakroutinesContext context) : base(context) { }

        public Task<ProcessResult> Add(Trip trip)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<List<Trip>>> GetByCategoty(string category)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<List<Trip>>> GetByNearToMe(float latitude, float longitude)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<Trip>> GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Update(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}

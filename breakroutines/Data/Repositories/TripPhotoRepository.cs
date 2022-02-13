using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;

namespace breakroutines.Data.Repositoryes
{
    public class TripPhotoRepository : BaseService, ITripPhotoRepository
    {
        public TripPhotoRepository(breakroutinesContext context) : base(context) { }

        public Task<ProcessResult> Add(TripPhoto tripPhoto)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Delete(TripPhoto tripPhoto)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<List<TripPhoto>>> GetAllByTripId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<TripPhoto>> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Update(TripPhoto tripPhoto)
        {
            throw new NotImplementedException();
        }
    }
}

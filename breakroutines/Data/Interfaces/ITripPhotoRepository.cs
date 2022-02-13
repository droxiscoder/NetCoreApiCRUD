using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;

namespace breakroutines.Data.Interfaces
{
    public interface ITripPhotoRepository
    {
        Task<ProcessResult<List<TripPhoto>>> GetAllByTripId(int id);
        Task<ProcessResult<TripPhoto>> GetSingle(int id);
        Task<ProcessResult> Add(TripPhoto tripPhoto);
        Task<ProcessResult> Update(TripPhoto tripPhoto);
        Task<ProcessResult> Delete(TripPhoto tripPhoto);
    }
}

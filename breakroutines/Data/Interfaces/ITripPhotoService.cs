using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;
using breakroutines.Utils;

namespace breakroutines.Data.Interfaces
{
    public interface ITripPhotoService
    {
        Task<ProcessResult<List<TripPhoto>>> GetAllByTripId(long id);
        Task<ProcessResult<TripPhoto>> GetSingle(long id);
        Task<ProcessResult> Add(TripPhoto tripPhoto);
        Task<ProcessResult> Delete(long id);
    }
}

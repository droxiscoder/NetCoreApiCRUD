using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;

namespace breakroutines.Data.Interfaces
{
    public interface ITripRepository
    {
        Task<ProcessResult<List<Trip>>> GetByCategoty(string category);
        Task<ProcessResult<List<Trip>>> GetByNearToMe(float latitude, float longitude);
        Task<ProcessResult<Trip>> GetSingleById(int id);
        Task<ProcessResult> Add(Trip trip);
        Task<ProcessResult> Update(Trip trip);
    }
}

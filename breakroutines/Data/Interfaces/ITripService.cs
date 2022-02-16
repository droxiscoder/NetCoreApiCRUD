using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;
using breakroutines.Utils;

namespace breakroutines.Data.Interfaces
{
    public interface ITripService
    {
        Task<ProcessResult<List<Trip>>> GetByCategoty(string category);
        Task<ProcessResult<List<Trip>>> GetByNearToMe(decimal latitude, decimal longitude);
        Task<ProcessResult<Trip>> GetSingleById(long id);
        Task<ProcessResult> Add(Trip trip);
        Task<ProcessResult> Update(Trip trip);
    }
}

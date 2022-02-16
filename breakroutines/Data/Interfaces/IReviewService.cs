using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;
using breakroutines.Utils;

namespace breakroutines.Data.Interfaces
{
    public interface IReviewService
    {
        Task<ProcessResult<List<Review>>> GetAllByTripId(long id);
        Task<ProcessResult<Review>> GetSingle(long id);
        Task<ProcessResult> Add(Review review);
        Task<ProcessResult> Update(Review review);
        Task<ProcessResult> Delete(long id);
    }
}

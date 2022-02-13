using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;

namespace breakroutines.Data.Interfaces
{
    public interface IReviewRepository
    {
        Task<ProcessResult<List<Review>>> GetAllByTripId(int id);
        Task<ProcessResult<Review>> GetSingle(int id);
        Task<ProcessResult> Add(Review review);
        Task<ProcessResult> Update(Review review);
        Task<ProcessResult> Delete(Review review);
    }
}

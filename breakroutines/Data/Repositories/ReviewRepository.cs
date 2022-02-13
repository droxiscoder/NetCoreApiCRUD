using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;

namespace breakroutines.Data.Repositoryes
{
    public class ReviewRepository : BaseService, IReviewRepository
    {
        public ReviewRepository(breakroutinesContext context) : base(context) { }

        public Task<ProcessResult> Add(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Delete(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<List<Review>>> GetAllByTripId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<Review>> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Update(Review review)
        {
            throw new NotImplementedException();
        }
    }   
}

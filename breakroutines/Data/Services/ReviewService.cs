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
    public class ReviewService : BaseService, IReviewService
    {
        public ReviewService(breakroutinesContext context) : base(context) { }

        public async Task<ProcessResult> Add(Review review)
        {
            Func<Task> action = async () =>
            {
                await context.Reviews.AddAsync(review);
                await context.SaveChangesAsync();
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult> Delete(long id)
        {
            Func<Task> action = async () =>
            {
                var review = await context.Reviews.Where(x => x.ReviewId == id).SingleAsync();
                context.Remove(review);
                await context.SaveChangesAsync();
            };

            return await Process.RunAsync(action);
        }


        public async Task<ProcessResult<List<Review>>> GetAllByTripId(long id)
        {
            Func<Task<List<Review>>> action = async () =>
            {
                var reviews = await context.Reviews.Where(x => x.TripId == id).ToListAsync();
                return reviews;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<Review>> GetSingle(long id)
        {
            Func<Task<Review>> action = async () =>
            {
                var review = await context.Reviews.Where(x => x.ReviewId == id).SingleAsync();
                return review;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult> Update(Review review)
        {
            Func<Task> action = async () =>
            {
                var viewResponse = await context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == review.ReviewId);

                if (viewResponse != null)
                {
                    viewResponse.Description = review.Description;
                    viewResponse.Score = review.Score;

                    await context.SaveChangesAsync();
                }
            };

            return await Process.RunAsync(action);

        }
    }   
}

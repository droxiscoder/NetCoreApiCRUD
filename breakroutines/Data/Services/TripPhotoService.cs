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
    public class TripPhotoService : BaseService, ITripPhotoService
    {
        public TripPhotoService(breakroutinesContext context) : base(context) { }

        public async Task<ProcessResult> Add(TripPhoto tripPhoto)
        {
            Func<Task> action = async () =>
            {
                await context.TripPhotos.AddAsync(tripPhoto);
                await context.SaveChangesAsync();
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult> Delete(long id)
        {
            Func<Task> action = async () =>
            {
                var tripPhoto = await context.TripPhotos.Where(x => x.TripPhotoId == id).SingleAsync();
                context.Remove(tripPhoto);
                await context.SaveChangesAsync();
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<List<TripPhoto>>> GetAllByTripId(long id)
        {
            Func<Task<List<TripPhoto>>> action = async () =>
            {
                var tripPhotos = await context.TripPhotos.Where(x => x.TripId == id).ToListAsync();
                return tripPhotos;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<TripPhoto>> GetSingle(long id)
        {
            Func<Task<TripPhoto>> action = async () =>
            {
                var tripPhoto = await context.TripPhotos.Where(x => x.TripPhotoId == id).SingleAsync();
                return tripPhoto;
            };

            return await Process.RunAsync(action);
        }

    }
}

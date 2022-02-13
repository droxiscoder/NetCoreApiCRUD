using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;
using Microsoft.EntityFrameworkCore;

namespace breakroutines.Data.Repositoryes
{
    public class UserRepository : BaseService, IUserRepository
    {
        public UserRepository(breakroutinesContext context) : base(context) { }

        public async Task<ProcessResult> Add(User user)
        {
            Func<Task> action = async () =>
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<User>> GetSingleByEmail(string email)
        {
            Func<Task<User>> action = async () =>
            {
                var user = await context.Users.Where(x => x.Email == email).SingleAsync();
                return user;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult<User>> GetSingleById(int id)
        {
            Func<Task<User>> action = async () =>
            {
                var user = await context.Users.Where(x => x.UserId == id).SingleAsync();
                return user;
            };

            return await Process.RunAsync(action);
        }

        public async Task<ProcessResult> Update(User user)
        {
            Func<Task> action = async () =>
            {
                var userResponse = await context.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);

                if (userResponse != null)
                {
                    userResponse.FirstName = user.FirstName;
                    userResponse.LastName = user.LastName;
                    userResponse.PhoneNumber = user.PhoneNumber;
                    userResponse.ProfilePic = user.ProfilePic;
                    userResponse.IsActive = user.IsActive;
                    userResponse.Address = user.Address;
                    userResponse.Address = user.Address;
                    userResponse.City = user.City;
                    userResponse.State = user.State;

                    await context.SaveChangesAsync();
                }
            };

            return await Process.RunAsync(action);
            
        }
    }
}
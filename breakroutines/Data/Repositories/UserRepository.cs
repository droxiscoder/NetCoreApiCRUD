using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Data.Repositories;
using breakroutines.Models;

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

        public Task<ProcessResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<User>> GetSingleByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult<User>> GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
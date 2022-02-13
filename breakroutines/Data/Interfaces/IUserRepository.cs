using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;

namespace breakroutines.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<ProcessResult<User>> GetSingleByEmail(string email);
        Task<ProcessResult<User>> GetSingleById(int id);
        Task<ProcessResult> Add(User user);
        Task<ProcessResult> Update(User user);
    }
}

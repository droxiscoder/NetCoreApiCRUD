using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Models;
using breakroutines.Utils;

namespace breakroutines.Data.Interfaces
{
    public interface IUserService
    {
        Task<ProcessResult<User>> GetSingleByEmail(string email);
        Task<ProcessResult<User>> GetSingleById(int id);
        Task<ProcessResult> Add(User user);
        Task<ProcessResult> Update(User user);
    }
}

using System;
using breakroutines.Models;

namespace breakroutines.Data.Repositories
{
    public abstract class BaseService
    {
        protected readonly breakroutinesContext context;

        public BaseService(breakroutinesContext context)
        {
            this.context = context;
        }
    }
}

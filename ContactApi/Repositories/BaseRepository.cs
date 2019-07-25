using ContactApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}

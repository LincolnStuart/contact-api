using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Get(int id);
        IList<T> All();
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}

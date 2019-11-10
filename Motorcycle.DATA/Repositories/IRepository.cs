using Motorcycle.DATA.Model;
using System.Collections.Generic;

namespace Motorcycle.DATA.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int id);
        bool Add(T model);
        T Update(T model,int id);
        bool Delete(int id);
    }
}

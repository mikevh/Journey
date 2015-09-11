using System.Linq;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Set { get; }
        IQueryable<T> All { get; }
        T Find(int id);
        void Delete(int id);
        void Upsert(T obj);
    }
}
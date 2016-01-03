using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Set { get; }
        IQueryable<T> All { get; }
        T Find(int id);
        bool Delete(int id);
        void Upsert(T obj);
    }

    public abstract partial class Repository<T> : IDisposable where T : class, IHasId, new()
    {
        protected readonly DB DB;

        protected Repository(DB db) {
            DB = db;
        }

        public virtual DbSet<T> Set => DB.Set<T>();

        public virtual IQueryable<T> All => Set.AsQueryable();

        public virtual T Find(int id) {
            return Set.SingleOrDefault(x => x.Id == id);
        }

        public virtual bool Delete(int id) {
            var item = Find(id);
            if (item != null) {
                Set.Remove(item);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public virtual void Upsert(T obj) {
            if (obj.Id != default(int)) {
                DB.Entry(obj).State = EntityState.Modified;
            }
            else {
                Set.Add(obj);
            }
            DB.SaveChanges();
        }

        public virtual void Dispose() {
            DB.Dispose();
        }
    }
}

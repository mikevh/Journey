using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public abstract class Repository<T> where T : class, IHasId
    {
        protected readonly DB DB;

        protected Repository(DB db) {
            DB = db;
        }

        public DbSet<T> Set => DB.Set<T>();

        public IQueryable<T> All => Set.AsQueryable();

        public T Find(int id) {
            return Set.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(int id) {
            var item = Find(id);
            if (item != null) {
                Set.Remove(item);
                DB.SaveChanges();
            }
        }

        public void Upsert(T obj) {
            if (obj.Id != default(int)) {
                DB.Entry(obj).State = EntityState.Modified;
            }
            else {
                Set.Add(obj);
            }
            DB.SaveChanges();
        }
    }
}

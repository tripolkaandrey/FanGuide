using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FanGuide.HelperClasses;
using FanGuide.Models;

namespace FanGuide.Domain
{
    public class AthletesRepository : IRepository<Athlete>
    {
        private ApplicationDbContext _context;
        private bool disposed = false;
        public AthletesRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Athlete> GetList(params Expression<Func<Athlete, object>>[] includes)
        {
            return _context.Athletes.IncludeMultiple<Athlete>(includes);
        }

        public Athlete Get(int id)
        {
            return _context.Athletes.Find(id);
        }

        public void Create(Athlete item)
        {
            _context.Athletes.Add(item);
            Save();
        }

        public void Update(Athlete item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var athlete = _context.Athletes.SingleOrDefault(x => x.Id == id);

            if (athlete != null)
                _context.Athletes.Remove(athlete);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
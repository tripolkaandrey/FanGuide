using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FanGuide.Classes;
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
        }

        public void Update(Athlete item)
        {
            var athleteInDb = _context.Athletes.Single(m => m.Id == item.Id);

            athleteInDb.Name = item.Name;
            athleteInDb.SportId = item.SportId;
            athleteInDb.Weight = item.Weight;
            athleteInDb.Height = item.Height;
            athleteInDb.Age = item.Age;
            athleteInDb.Citizenship = item.Citizenship;
            athleteInDb.Achievements = item.Achievements;
        }

        public void Delete(int id)
        {
            var athlete = _context.Athletes.SingleOrDefault(x => x.Id == id);

            if (athlete != null)
                _context.Athletes.Remove(athlete);
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
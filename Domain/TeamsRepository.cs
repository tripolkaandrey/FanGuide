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
    public class TeamsRepository:IRepository<Team>
    {
        private ApplicationDbContext _context;
        private bool disposed = false;
        public TeamsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Team> GetList(params Expression<Func<Team, object>>[] includes)
        {
            return _context.Teams.IncludeMultiple<Team>(includes);
        }

        public Team Get(int id)
        {
            return _context.Teams.SingleOrDefault(x=>x.Id == id);
        }

        public void Create(Team item)
        {
            _context.Teams.Add(item);
            Save();
        }

        public void Update(Team item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);

            if (team != null)
                _context.Teams.Remove(team);
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
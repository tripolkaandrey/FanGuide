using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FanGuide.Classes;
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
            return _context.Teams.Find(id);
        }

        public void Create(Team item)
        {
            _context.Teams.Add(item);
        }

        public void Update(Team item)
        {
            var teamInDb = _context.Teams.Single(m => m.Id == item.Id);
            teamInDb.Name = item.Name;
        }

        public void Delete(int id)
        {
            var team = _context.Teams.SingleOrDefault(x => x.Id == id);

            if (team != null)
                _context.Teams.Remove(team);
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
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
    public class TeamRolesRepository:IRepository<TeamRole>
    {
        private ApplicationDbContext _context;
        private bool disposed = false;
        public TeamRolesRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TeamRole> GetList(params Expression<Func<TeamRole, object>>[] includes)
        {
            return _context.TeamRoles.IncludeMultiple<TeamRole>(includes);
        }

        public TeamRole Get(int id)
        {
            return _context.TeamRoles.Find(id);
        }

        public void Create(TeamRole item)
        {
            _context.TeamRoles.Add(item);
        }

        public void Update(TeamRole item)
        {
            _context.Entry(item).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            var teamRole = _context.TeamRoles.SingleOrDefault(x => x.Id == id);

            if (teamRole != null)
                _context.TeamRoles.Remove(teamRole);
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
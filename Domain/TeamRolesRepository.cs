using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FanGuide.Classes;
using FanGuide.Models;

namespace FanGuide.Domain
{
    public class TeamRolesRepository:IRepository<TeamRole>
    {
        private ApplicationDbContext TeamRoles_db;
        private bool disposed = false;
        public TeamRolesRepository()
        {
            TeamRoles_db = new ApplicationDbContext();
        }

        public IEnumerable<TeamRole> GetList(params Expression<Func<TeamRole, object>>[] includes)
        {
            return TeamRoles_db.TeamRoles.IncludeMultiple<TeamRole>(includes);
        }

        public TeamRole Get(int id)
        {
            return TeamRoles_db.TeamRoles.Find(id);
        }

        public void Create(TeamRole item)
        {
            TeamRoles_db.TeamRoles.Add(item);
        }

        public void Update(TeamRole item)
        {
            var teamRoleInDb = TeamRoles_db.TeamRoles.Single(m => m.Id == item.Id);
            teamRoleInDb.Name = item.Name;
        }

        public void Delete(int id)
        {
            var teamRole = TeamRoles_db.TeamRoles.SingleOrDefault(x => x.Id == id);

            if (teamRole != null)
                TeamRoles_db.TeamRoles.Remove(teamRole);
        }

        public void Save()
        {
            TeamRoles_db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    TeamRoles_db.Dispose();
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FanGuide.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
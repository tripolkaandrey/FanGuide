﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FanGuide.Classes;
using FanGuide.Models;

namespace FanGuide.Domain
{
    public class SportsRepository:IRepository<Sport>
    {
        private ApplicationDbContext _context;
        private bool disposed = false;
        public SportsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Sport> GetList(params Expression<Func<Sport, object>>[] includes)
        {
            return _context.Sports.IncludeMultiple<Sport>(includes);
        }

        public Sport Get(int id)
        {
            return _context.Sports.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Sport item)
        {
            _context.Sports.Add(item);
        }

        public void Update(Sport item)
        {
            var sportInDb = _context.Sports.Single(m => m.Id == item.Id);

            sportInDb.Name = item.Name;
        }

        public void Delete(int id)
        {
            var sport = _context.Sports.SingleOrDefault(x => x.Id == id);

            if (sport != null)
                _context.Sports.Remove(sport);
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
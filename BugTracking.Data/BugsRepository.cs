using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Data
{
    public class BugsRepository : GenericRepository<Bug>, IBugsRepository
    {
        public BugsRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<Bug> AllWithCategories()
        {
            return this.DbSet.Include(x => x.Category).AsQueryable();
        }
    }
}

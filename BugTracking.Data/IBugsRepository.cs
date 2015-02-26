using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Data
{
    public interface IBugsRepository : IRepository<Bug>
    {
        IQueryable<Bug> AllWithCategories();
    }
}

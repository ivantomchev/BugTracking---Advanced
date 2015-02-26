using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Data
{
    public interface IUowData : IDisposable
    {
        IBugsRepository Bugs { get; }

        IRepository<BugsCategory> BugsCategories { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}

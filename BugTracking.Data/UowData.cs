using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Data
{
    public class UowData : IUowData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UowData()
            : this(new DataContext())
        {
        }

        public UowData(DbContext context)
        {
            this.context = context;
        }

        public IBugsRepository Bugs
        {
            get
            {
                return (IBugsRepository)this.GetRepository<Bug>();
            }
        }

        public IRepository<BugsCategory> BugsCategories
        {
            get
            {
                return this.GetRepository<BugsCategory>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                if (typeof(T) == typeof(Bug))
                {
                    type = typeof(BugsRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}

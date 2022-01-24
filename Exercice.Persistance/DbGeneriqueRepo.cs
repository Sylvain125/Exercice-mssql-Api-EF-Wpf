using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Persistance
{
    public class DbGeneriqueRepo<T> : IGeneriqueRepo<T> where T : class, new()
    {
        private DbContext Context { get; }

        public DbGeneriqueRepo(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Persistance
{
    public interface IGeneriqueRepo<T> where T : class, new()
    {
        IEnumerable<T> GetAll();

        void Add(T entity);
    }
}

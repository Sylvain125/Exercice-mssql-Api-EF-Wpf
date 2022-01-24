using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Persistance
{
    internal class FakeGenericRepo<T> : IGeneriqueRepo<T> where T : class, new()
    {

        private readonly List<T> _listEntity = new List<T>();
        private readonly Fixture _fixture = new Fixture();

        public FakeGenericRepo()
        {
            _listEntity = _fixture.CreateMany<T>(15).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _listEntity;
        }

        public void Add(T entity)
        {
            _listEntity.Add(entity);
        }
    }
}

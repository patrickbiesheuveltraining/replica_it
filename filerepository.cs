using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    internal class FileRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T> where T: Entity
    {
        private List<T> _repositoryList = new List<T>();
        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            foreach (var item in _repositoryList) 
            {
                yield return item;
            }
        }

        public void Insert(T item)
        {
            _repositoryList.Add(item);
        }
    }
}

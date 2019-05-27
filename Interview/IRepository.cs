using System;
using System.Collections.Generic;

namespace Interview
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        bool Delete(IComparable id);
        bool Save(T item);
        T FindById(IComparable id);
    }

    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public T FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public bool Save(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IComparable id)
        {
            throw new NotImplementedException();
        }
    }
}

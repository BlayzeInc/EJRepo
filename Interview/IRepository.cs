using System;
using System.Collections.Generic;

namespace Interview
{
    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        void Delete(IComparable id);
        void Save(T item);
        T FindById(IComparable id);
    }

    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private List<T> objects;

        public Repository()
        {
            objects = new List<T>(); 
        }

        public IEnumerable<T> All()
        {
            return objects;
        }

        public T FindById(IComparable id)
        {
            return objects.Find(MatchId(id));
        }

        private static Predicate<T> MatchId(IComparable id)
        {
            return m => m.Id.Equals(id);
        }

        public void Save(T item)
        {
            objects.Add(item);
        }

        public void Delete(IComparable id)
        {
            objects.RemoveAll(MatchId(id));
        }
    }
}

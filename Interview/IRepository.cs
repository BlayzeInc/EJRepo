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
            T obj = objects.Find(MatchId(id));
            if(obj != null)
            {
                return obj;
            }
            else
            {
                ArgumentException argEx = new ArgumentException("No object found matching this Id");
                throw argEx;
            }
            
        }

        private static Predicate<T> MatchId(IComparable id)
        {
            return m => m.Id.Equals(id);
        }

        public void Save(T item)
        {
            T obj = objects.Find(MatchId(item.Id));
            if (obj == null)
            {
                objects.Add(item);
            }
            else
            {
                ArgumentException argEx = new ArgumentException("Duplicate object found matching this id");
                throw argEx;
            }
            
        }

        public void Delete(IComparable id)
        {
            objects.RemoveAll(MatchId(id));
        }
    }
}

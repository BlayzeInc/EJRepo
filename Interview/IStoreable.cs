using System;

namespace Interview
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }

    public class Storable : IStoreable
    {
        public IComparable Id { get; set; }

        public Storable(IComparable id)
        {
            Id = id;
        }
    }
}
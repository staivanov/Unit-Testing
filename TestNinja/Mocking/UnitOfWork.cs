using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}
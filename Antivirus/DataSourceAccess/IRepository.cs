using System.Collections.Generic;

namespace DataSourceAccess
{
    public interface IRepository<T> where T : class
    {
        public bool Add(T item);
        public bool Remove(T item);
        public bool Update(T item);
        public List<T> GetAllItems();
        public T GetItem(int id);
    }
}
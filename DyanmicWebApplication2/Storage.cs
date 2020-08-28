using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicWebApplication
{
    public interface IStorage<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void AddOrUpdate(Guid id, T item);
    }

    /// <summary>
    /// For demo purposes. This should be registered as a singleton
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Storage<T> : IStorage<T> where T : class
    {
        private Dictionary<Guid, T> storage = new Dictionary<Guid, T>();

        public IEnumerable<T> GetAll() => storage.Values;

        public T GetById(Guid id)
        {
            return storage.FirstOrDefault(x => x.Key == id).Value;
        }

        public void AddOrUpdate(Guid id, T item)
        {
            storage[id] = item;
        }
    }
}

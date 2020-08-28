﻿using Microsoft.EntityFrameworkCore;
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
    /// Naive implementation for demo purposes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFStorage<T> : IStorage<T> where T : class
    {
        private readonly AppDbContext dbContext;

        private readonly DbSet<T> dbSet;

        public EFStorage(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            var propType = typeof(DbSet<>).MakeGenericType(typeof(T));

            dbSet = typeof(AppDbContext).GetProperties().Single(x => x.PropertyType == propType).GetValue(dbContext) as DbSet<T>;
        }

        public void AddOrUpdate(Guid id, T item)
        {
            var existing = dbSet.Find(id);
            dbSet.Attach(item);
            if (existing == null)
            {
                dbContext.Entry(item).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(item).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll() =>
            dbSet.ToList();

        public T GetById(Guid id) =>
            dbSet.Find(id);
    }
}

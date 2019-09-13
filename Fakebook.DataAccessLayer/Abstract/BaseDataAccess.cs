using Fakebook.CoreLayer.DataAccessLayer;
using Fakebook.CoreLayer.EntitiesLayer;
using Fakebook.CoreLayer.EntitiesLayer.Enum;
using Fakebook.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Fakebook.DataAccessLayer.Abstract
{
    public class BaseDataAccess<T> : ICoreDataAccess<T> where T : CoreEntity
    {
        private ProjectContext _context;

        public BaseDataAccess()
        {
            _context = new ProjectContext();
            //_context.Posts.Select(p=>p);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public void Update(T item)
        {
            T itemToBeUpdated = GetByID(item.ID);
            DbEntityEntry entry = _context.Entry(itemToBeUpdated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Save();
        }

        public List<T> GetActive()
        {
            return _context
                .Set<T>()
                .Where(x => x.Status == Status.Active ||
                            x.Status == Status.Updated)
                .ToList();
        }

        public void Remove(Guid id)
        {
            T item = GetByID(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }
    }
}

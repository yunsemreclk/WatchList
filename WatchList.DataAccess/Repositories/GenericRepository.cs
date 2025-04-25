using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchList.DataAccess.Abstract;
using WatchList.DataAccess.Context;

namespace WatchList.DataAccess.Repositories
{
    public class GenericRepository<T>(WatchListContext _context) : IRepository<T> where T : class //2- (WatchListContext _context) primery constarcter yapısı; yeni yöntem
    {
        //1-private readonly WatchListContext _context; // ctrl. generic constracter; eski yöntem
        public DbSet<T> Table { get => _context.Set<T>(); }
        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity) //Tabloya eklemem
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entitiy = Table.Find(id);
            Table.Remove(entitiy);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count(); //Where içine predicate şart
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault(); // tek bir değer
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}

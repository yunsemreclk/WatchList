using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace WatchList.DataAccess.Abstract
{
    public interface IRepository<T> where T : class // T bir sınıftır diyoruz, imzaları burada atıyoruz içeriğini GenericRepository de dolduracağız
    {
        List<T> GetList();

        T GetByFilter(Expression<Func<T, bool>> predicate); //şarta göre tek bir değer getirme

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        int Count();

        int FilteredCount(Expression<Func<T,bool>> predicate); //şarta göre count getirme

        List<T> GetFilteredList(Expression<Func<T,bool>> predicate); //şarta göre listeleme

    }
}

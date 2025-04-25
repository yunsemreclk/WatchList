using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Business.Absract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();

        T TGetByFilter(Expression<Func<T, bool>> predicate); //şarta göre tek bir değer getirme

        T TGetById(int id);

        void TCreate(T entity);

        void TUpdate(T entity);

        void TDelete(int id);

        int TCount();

        int TFilteredCount(Expression<Func<T, bool>> predicate); //şarta göre count getirme

        List<T> TGetFilteredList(Expression<Func<T, bool>> predicate); //şarta göre listeleme
    }
}

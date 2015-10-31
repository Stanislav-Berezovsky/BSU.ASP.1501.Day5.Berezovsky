using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public interface IBookRepository<T>
    {
        void Add(T book);
        void Delete(T book);
        T Search(Func<T, bool> func);
        List<T> SearchBooks(Predicate<T> match);
        List<T> Output();
    }
}

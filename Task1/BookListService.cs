using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class BookListService
    {
        private IBookRepository<Book> R { get; set; }


        public BookListService(IBookRepository<Book> repository)
        {
            this.R = repository;
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();        
            R.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            R.Delete(book);
        }

        public List<Book> FindBooks(Predicate<Book> match)
        {
            return R.SearchBooks(match);
        }

        public Book FindBook(Func<Book,bool> func)
        {
           return R.Search(func);
        }

        public IEnumerable<Book> SortBook(Func<Book, object> func)
        {
            return R.Output().OrderBy(func);
        }
    }
}

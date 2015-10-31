using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1;

namespace ConsoleForTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "Books.txt";
            IBookRepository<Book> rep = new Repository(path);
            var bookService = new BookListService(rep);
            Book book = new Book("qqq", "ee", "aaa", 3);
            
            //bookService.AddBook(book);

           // bookService.DeleteBook(book);
            
            
            var books = bookService.SortBook(x=>x.Publication);
            foreach (var b in books)
            {
                Console.Write("{0}\t",b.Author);
                Console.Write("{0}\t", b.Title);
                Console.Write("{0}\t", b.Genre);
                Console.Write("{0}\t", b.Publication);
                Console.WriteLine();
            }

            Console.WriteLine();
            var _books = bookService.FindBooks(x => x.Author == "qqq");
            foreach (var b in _books)
            {
                Console.Write("{0}\t", b.Author);
                Console.Write("{0}\t", b.Title);
                Console.Write("{0}\t", b.Genre);
                Console.Write("{0}\t", b.Publication);
                Console.WriteLine();
            }

            Console.WriteLine();
            var find = bookService.FindBook(x => x.Author == "qqq");
            Console.Write("{0}\t{1}\t{2}\t{3}",find.Author,find.Title,find.Genre,find.Publication);
            Console.ReadKey();
        }
    }
}

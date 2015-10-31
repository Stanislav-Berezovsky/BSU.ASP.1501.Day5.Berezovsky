using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Repository : IBookRepository<Book>
    {
        string path;

        public Repository(string filePath)
        {
            this.path = filePath;
        }

        public void Add(Book book)
        {
            var books = Reader();
            foreach (var b in books)
            {
                if((b.Equals(book)))
                    throw new Exception("This book exists in repository");
            }
            using (var writer = new BinaryWriter(new FileStream(path, FileMode.Append, FileAccess.Write)))
            {
                writer.Write(book.Author);
                writer.Write(book.Title);
                writer.Write(book.Genre);
                writer.Write(book.Publication);
            }
        }

        public void Delete(Book book)
        {
            if (book == null)
                throw new ArgumentException();
            var books = Reader();
            bool isDelete = false;
            isDelete =  books.Remove(book);
            if (!isDelete)
                throw new Exception("This book doesn't exists in repository");
            CreateFile(books);
        }


        public Book Search(Func<Book, bool> func)
        {
            return Reader().FirstOrDefault(func);
        }
        public List<Book> SearchBooks(Predicate<Book> match)
        {
            return Reader().FindAll(match);
        }


        public List<Book> Output()
        {
            return Reader();
        }


        private List<Book> Reader()
        {
            var books = new List<Book>();
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                books.Add(new Book( reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32()));
            }
            reader.Close();
            return books;            
        }


        


        private void CreateFile(List<Book> books)
        {
            using (var writer = new BinaryWriter(new FileStream(path, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Genre);
                    writer.Write(book.Publication);
               }
            }
        }






    }
}

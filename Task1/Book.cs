using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        private int _publication;
        public int Publication
        {
            get
            {
                return _publication;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentException();
                _publication = value;
            }
        }

        public Book(string author, string title, string genre, int publication)
        {
            this.Author = author;
            this.Title = title;
            this.Genre = genre;
            this.Publication = publication;
        }


        public int CompareTo(Book other)
        {
            int compare = this.Author.CompareTo(other.Author);
            if (compare != 0)
            {
                return compare;
            }
            compare = this.Title.CompareTo(other.Title);
            if (compare != 0)
            {
                return compare;
            }
            compare = this.Genre.CompareTo(other.Genre);
            if (compare != 0)
            {
                return compare;
            }
            return this.Publication.CompareTo(other.Publication);
        }






        public bool Equals(Book other)
        {
            if (other == null)
                return false;
            if (this.Author == other.Author && this.Title == other.Title && this.Genre == other.Genre && this.Publication == other.Publication)
                return true;
            return false;
        }
    }
}

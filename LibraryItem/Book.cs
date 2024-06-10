using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryItem
{
    public class Book:LibraryItem
    {
        private string Genre;
        public void setGenre(string genre)
        {
            this.Genre = genre;
        }
        public string getGenre()
        {
            return this.Genre;
        }

        public Book() : base() {
            this.setGenre("Default Genre");
        }
        public Book(string title, string author, 
            bool available, DateOnly publicationDate, 
            string genre)
            :base(title,author,available,publicationDate)
        {
            this.setGenre(genre);
        }

        public override void CheckOut()
        {
            this.setAvailable(false);
            Console.WriteLine($"Updated Book '{this.getTitle()}' available to False");
        }
        public override void ReturnItem()
        {
            this.setAvailable(true);
            Console.WriteLine($"Updated Book '{this.getTitle()}' available to True");
        }
        public override string ToString()
        {
            return $"The book: {this.getTitle()}, author: {this.getAuthor()}, Avaiable status: {this.getAvailable()}," +
                $" Publication Date: {this.getPublicationDate()}, Genre: {this.getGenre()}";
        }
    }
}

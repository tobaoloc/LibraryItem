using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryItem
{
    public abstract class LibraryItem
    {
        private string Title;
        private string Author;
        private bool Available;
        private DateOnly PublicationDate;

        public LibraryItem()
        {
            this.setTitle("Default LibraryItem title");
            this.setAuthor("Default LibraryItem author");
            this.setAvailable(true);
            this.setPublicationDate(new DateOnly());
        }
        public LibraryItem(string title, string author,
            bool available, DateOnly publicationDate)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.");
            
            this.setTitle(title);
            this.setAuthor(author);
            this.setAvailable(available);
            this.setPublicationDate(publicationDate);
        }
            
        public abstract void CheckOut() ;
        public abstract void ReturnItem() ;

        public void setTitle(string title)
        {
            this.Title = title;
        }
        public string getTitle()
        {
            return this.Title;
        }
        public void setAuthor(string author) 
        { 
            this.Author = author;
        }
        public string getAuthor()
        {
            return this.Author;
        }
        public void setAvailable(bool avaiable)
        {
            this.Available = avaiable;
        }
        public bool getAvailable() 
        {
            return this.Available;
        }
        public void setPublicationDate(DateOnly publicationDate)
        {
            this.PublicationDate = publicationDate;
        }

        public DateOnly getPublicationDate() { 
            return this.PublicationDate;
        }

    }
}

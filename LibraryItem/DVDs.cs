using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryItem
{
    public class DVDs:LibraryItem
    {
        private int RunTime;
        public void setRunTime(int runtime)
        {
            this.RunTime = runtime;
        }
        public int getRunTime()
        {
            return this.RunTime;
        }
        public DVDs() : base()
        {
            this.setRunTime(3600);
        }
        public DVDs(string title, string author,
            bool available, DateOnly publicationDate,
            int RunTime)
            : base(title, author, available, publicationDate)
        {
            this.setRunTime(3600);
        }

        public override void CheckOut()
        {
            this.setAvailable(false);
            Console.WriteLine($"Updated DVDs '{this.getTitle()}' available to False");
        }
        public override void ReturnItem()
        {
            this.setAvailable(true);
            Console.WriteLine($"Updated DVDs '{this.getTitle()}' available to True");
        }
        public override string ToString()
        {
            return $"The DVDs: {this.getTitle()}, author: {this.getAuthor()}, Avaiable status: {this.getAvailable()}," +
                $" Publication Date: {this.getPublicationDate()}, Runtime: {this.getRunTime()}";
        }
    }
}

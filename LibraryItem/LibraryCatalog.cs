using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryItem
{
    public class LibraryCatalog
    {
        public List<LibraryItem> Items = new List<LibraryItem>();

        public void AddItem(LibraryItem item)
        {
            Items.Add(item);
        }
        public void FindItem(string SearchTerm)
        {
            bool found = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].getTitle() == SearchTerm 
                    || this.Items[i].getAuthor() == SearchTerm)
                {
                    found = true;
                    Console.WriteLine($"Found an items: {Items[i].ToString()}");
                }
            }
            if (!found)
            {
                Console.WriteLine("Not found");
            }
        }
        public int CountItems()
        {
            return Items.Count;
        }
    }
}

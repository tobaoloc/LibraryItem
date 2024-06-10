using LibraryItem;

class MainProgram
{
    static void Main(String[] agrs)
    {
        /*DateOnly dateOnly = new DateOnly(2024,5,25);
        Book book = new Book("the Book","The Author",true,dateOnly,"The Genre");
        book.CheckOut();
 
        DVDs dvd = new DVDs("The new DVDs","The DVD Authors",true, dateOnly, 300);
        DVDs dvd2 = new DVDs("The new DVDs 2","The DVD Authors2",true, dateOnly, 300);
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        catalog.AddItem(dvd);
        catalog.AddItem(dvd2);
        catalog.FindItem("The Author");
        */
        while (true)
        {
            Console.WriteLine("Pls choose a feature:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Enter Book");
            Console.WriteLine("2: Enter DVDs");
            Console.WriteLine("3: Find an Items");
            int feature = Convert.ToInt32(Console.ReadLine());
            LibraryCatalog catalog = new LibraryCatalog();  
            switch (feature)
            {
                case 0:
                    {
                        return;
                    }
                case 1:
                    {
                        Console.WriteLine("Pls enter Title");
                        String title = Console.ReadLine();
                        Console.WriteLine("Pls enter Author");
                        String author = Console.ReadLine();
                        Console.WriteLine("Pls enter Available, 1: Available,0: Not Available");

                        int availableText = Convert.ToInt32(Console.ReadLine());
                        
                        bool available = availableText !=0;

                        Console.WriteLine("Pls enter Publication Date. format: YYYY/MM/DD");
                        String publicationDate = Console.ReadLine();
                        String[] publicationDateFormatted = publicationDate.Split("/");
                        DateOnly date = new DateOnly(Convert.ToInt32(publicationDateFormatted[0]), Convert.ToInt32(publicationDateFormatted[1]),
                                Convert.ToInt32(publicationDateFormatted[2]) );
                        Console.WriteLine("Pls enter Genre:");
                        String genre = Console.ReadLine();
                        Book book = new Book(title,author,available,date,genre);
                        catalog.AddItem(book);
                        break;
                    }


            }
        }
        
    }
}
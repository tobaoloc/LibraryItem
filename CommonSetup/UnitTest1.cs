using LibraryItem;

public class CommonSetup
{
    protected Book book;
    protected DVDs dvd;
    protected LibraryCatalog catalog;

    public CommonSetup()
    {
        book = new Book("Test Book", "Test Author", true, new DateOnly(2021, 1, 1), "Test Genre");
        dvd = new DVDs("Test DVD", "Test Director", true, new DateOnly(2022, 2, 2), 120);
        catalog = new LibraryCatalog();
        catalog.AddItem(book);
        catalog.AddItem(dvd);
    }
}

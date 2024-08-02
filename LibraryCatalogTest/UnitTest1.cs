using LibraryItem;
namespace LibraryCatalogTest;

public class LibraryCatalogTest
{
    private Book book;
    private DVDs dvd;

    public LibraryCatalogTest()
    {
        book = new Book("Test Book", "Test Author", true, new DateOnly(2021, 1, 1), "Test Genre");
        dvd = new DVDs("Test DVDs", "Test Author", true, new DateOnly(2022, 2, 2), 120);
    }

    [Fact]
    public void LibraryCatalog_AddItem_IncreasesItemCount()
    {
        LibraryCatalog catalog = new LibraryCatalog();
        int initialCount = catalog.CountItems();
        catalog.AddItem(book);
        Assert.Equal(initialCount + 1, catalog.CountItems());
    }

    [Fact]
    public void LibraryCatalog_FindItem_ByTitle()
    {
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Test Book"));
        Assert.Contains("Found an items: " ,consoleOutput);
    }

    [Fact]
    public void LibraryCatalog_FindItem_ByAuthor()
    {
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Test Author"));
        Assert.Contains("Found an items: ", consoleOutput);
    }

    [Fact]
    public void LibraryCatalog_FindItem_NotFound()
    {
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Nonexistent item"));
        Assert.Equal("Not found", consoleOutput.Trim());
    }

    [Fact]
    public void LibraryCatalog_CountItems_ReturnsCorrectCount()
    {
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        catalog.AddItem(dvd);
        Assert.Equal(2, catalog.CountItems());
    }

    private string CaptureConsoleOutput(Action action)
    {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);
        action();
        Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        return consoleOutput.ToString();
    }
}

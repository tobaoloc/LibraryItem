using System;
using LibraryItem;
namespace AutomatedTesting;

public class Inlinetest
{
    [Theory]
    [InlineData("Test Book", "Test Author", true, 2021, 1, 1, "Test Genre")]
    public void Book_CheckOut_SetsAvailableToFalse(string title, string author, bool available, int year, int month, int day, string genre)
    {
        var book = new Book(title, author, available, new DateOnly(year, month, day), genre);
        book.CheckOut();
        Assert.False(book.getAvailable());
    }

    [Theory]
    [InlineData("Test Book", "Test Author", true, 2021, 1, 1, "Test Genre")]
    public void Book_ReturnItem_SetsAvailableToTrue(string title, string author, bool available, int year, int month, int day, string genre)
    {
        var book = new Book(title, author, available, new DateOnly(year, month, day), genre);
        book.CheckOut();
        book.ReturnItem();
        Assert.True(book.getAvailable());
    }

    [Theory]
    [InlineData("Test Book", "Test Author", true, 2021, 1, 1, "Test Genre")]
    public void Book_SetTitle_ValidTitle(string title, string author, bool available, int year, int month, int day, string genre)
    {
        var book = new Book(title, author, available, new DateOnly(year, month, day), genre);
        string newTitle = "New Book Title";
        book.setTitle(newTitle);
        Assert.Equal(newTitle, book.getTitle());
    }

    [Theory]
    [InlineData("Test Book", "Test Author", true, 2021, 1, 1, "Test Genre")]
    public void Book_SetAuthor_ValidAuthor(string title, string author, bool available, int year, int month, int day, string genre)
    {
        var book = new Book(title, author, available, new DateOnly(year, month, day), genre);
        string newAuthor = "New Book Author";
        book.setAuthor(newAuthor);
        Assert.Equal(newAuthor, book.getAuthor());
    }

    [Theory]
    [InlineData("Test Book", "Test Author", true, 2021, 1, 1, "Test Genre")]
    public void Book_SetGenre_ValidGenre(string title, string author, bool available, int year, int month, int day, string genre)
    {
        var book = new Book(title, author, available, new DateOnly(year, month, day), genre);
        string newGenre = "New Book Genre";
        book.setGenre(newGenre);
        Assert.Equal(newGenre, book.getGenre());
    }

}

public class ClassData
{
    [Theory]
    [ClassData(typeof(ClassTestData))]
    public void DVD_CheckOut_SetsAvailableToFalse(string title, string author, bool available, DateOnly publicationDate, int RunTime)
    {
        var dvd = new DVDs(title, author, available, publicationDate, RunTime);
        dvd.CheckOut();
        Assert.False(dvd.getAvailable());
    }
    [Theory]
    [ClassData(typeof(ClassTestData))]
    public void DVD_ReturnItem_SetsAvailableToTrue(string title, string author, bool available, DateOnly publicationDate, int RunTime)
    {
        var dvd = new DVDs(title, author, available, publicationDate, RunTime);
        dvd.CheckOut();
        dvd.ReturnItem();
        Assert.True(dvd.getAvailable());
    }
    [Theory]
    [ClassData(typeof(ClassTestData))]
    public void DVD_SetTitle_ValidTitle(string title, string author, bool available, DateOnly publicationDate, int RunTime)
    {
        var dvd = new DVDs(title, author, available, publicationDate, RunTime);
        string newTitle = "New DVD Title";
        dvd.setTitle(newTitle);
        Assert.Equal(newTitle, dvd.getTitle());
    }
    [Theory]
    [ClassData(typeof(ClassTestData))]
    public void DVD_SetAuthor_ValidAuthor(string title, string author, bool available, DateOnly publicationDate, int RunTime)
    {
        var dvd = new DVDs(title, author, available, publicationDate, RunTime);
        string newAuthor = "New DVD Author";
        dvd.setAuthor(newAuthor);
        Assert.Equal(newAuthor, dvd.getAuthor());
    }
    [Theory]
    [ClassData(typeof(ClassTestData))]
    public void DVD_SetRunTime_ValidRunTime(string title, string author, bool available, DateOnly publicationDate, int RunTime)
    {
        var dvd = new DVDs(title, author, available, publicationDate, RunTime);
        int newRunTime = 120;
        dvd.setRunTime(newRunTime);
        Assert.Equal(newRunTime, dvd.getRunTime());
    }
}

public class MemberData
{
    [Theory]
    [MemberData(nameof(Data))]
    public void LibraryCatalog_AddItem_IncreasesItemCount(string title, string author,
            bool available, DateOnly publicationDate,
            string genre)
    {
        var book = new Book(title, author, available, publicationDate, genre);
        LibraryCatalog catalog = new LibraryCatalog();
        int initialCount = catalog.CountItems();
        catalog.AddItem(book);
        Assert.Equal(initialCount + 1, catalog.CountItems());

    }

    [Theory]
    [MemberData(nameof(Data))]
    public void LibraryCatalog_FindItem_ByTitle(string title, string author,
            bool available, DateOnly publicationDate,
            string genre)
    {
        var book = new Book(title, author, available, publicationDate, genre);
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Test Book"));
        Assert.Contains("Found an items: ", consoleOutput);

    }

    [Theory]
    [MemberData(nameof(Data))]
    public void LibraryCatalog_FindItem_ByAuthor(string title, string author,
            bool available, DateOnly publicationDate,
            string genre)
    {
        var book = new Book(title, author, available, publicationDate, genre);
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Test Author"));
        Assert.Contains("Found an items: ", consoleOutput);

    }

    [Theory]
    [MemberData(nameof(Data))]
    public void LibraryCatalog_FindItem_NotFound(string title, string author,
            bool available, DateOnly publicationDate,
            string genre)
    {
        var book = new Book(title, author, available, publicationDate, genre);
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Nonexistent item"));
        Assert.Equal("Not found", consoleOutput.Trim());

    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
          new object[] {"Test Book", "Test Author", true, new DateOnly(2021, 1, 1), "Test Genre" }
          

    };
    private string CaptureConsoleOutput(Action action)
    {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);
        action();
        Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        return consoleOutput.ToString();
    }

    [Theory]
    [MemberData(nameof(DataBookDVDs))]
    public void LibraryCatalog_CountItems_ReturnsCorrectCount(Book book, DVDs dvd)
    {
        LibraryCatalog catalog = new LibraryCatalog();
        catalog.AddItem(book);
        catalog.AddItem(dvd);
        Assert.Equal(2, catalog.CountItems());

    }

    public static IEnumerable<object[]> DataBookDVDs => new List<object[]>
    {
        new object[] { new Book("Test Book1", "Test Author1", true, new DateOnly(2021, 1, 1), "Test Genre"),
            new DVDs("Test DVDs", "Test Author", true, new DateOnly(2022, 2, 2),120) },

    };

    
}

using LibraryItem;
namespace BookTest;

public class BookTest
{
    private Book book;

    public BookTest()
    {
        book = new Book("Test Book", "Test Author", true, new DateOnly(2021, 1, 1), "Test Genre");
    }

    
    [Fact]
    public void Book_CheckOut_SetsAvailableToFalse()
    {
        book.CheckOut();
        Assert.False(book.getAvailable());
    }

    [Fact]
    public void Book_ReturnItem_SetsAvailableToTrue()
    {
        book.CheckOut();
        book.ReturnItem();
        Assert.True(book.getAvailable());
    }

    [Fact]
    public void Book_SetTitle_ValidTitle()
    {
        string newTitle = "New Book Title";
        book.setTitle(newTitle);
        Assert.Equal(newTitle, book.getTitle());
    }

    [Fact]
    public void Book_SetAuthor_ValidAuthor()
    {
        string newAuthor = "New Book Author";
        book.setAuthor(newAuthor);
        Assert.Equal(newAuthor, book.getAuthor());
    }

    [Fact]
    public void Book_SetGenre_ValidGenre()
    {
        string newGenre = "New Book Genre";
        book.setGenre(newGenre);
        Assert.Equal(newGenre, book.getGenre());
    }
}

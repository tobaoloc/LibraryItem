// BookTest.cs
using LibraryItem;
using Xunit;

public class BookTest : CommonSetup
{
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
        string newAuthor = "New Author";
        book.setAuthor(newAuthor);
        Assert.Equal(newAuthor, book.getAuthor());
    }

    [Fact]
    public void Book_SetGenre_ValidGenre()
    {
        string newGenre = "New Genre";
        book.setGenre(newGenre);
        Assert.Equal(newGenre, book.getGenre());
    }
}

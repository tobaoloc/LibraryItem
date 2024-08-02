using LibraryItem;
namespace DVDsTest;

public class DVDsTest
{
    private DVDs dvd;

    public DVDsTest()
    {
        dvd = new DVDs("Test DVD", "Test Director", true, new DateOnly(2022, 2, 2), 120);
    }
    
    [Fact]
    public void DVD_CheckOut_SetsAvailableToFalse()
    {
        dvd.CheckOut();
        Assert.False(dvd.getAvailable());
    }

    [Fact]
    public void DVD_ReturnItem_SetsAvailableToTrue()
    {
        dvd.CheckOut();
        dvd.ReturnItem();
        Assert.True(dvd.getAvailable());
    }

    [Fact]
    public void DVD_SetTitle_ValidTitle()
    {
        string newTitle = "New DVD Title";
        dvd.setTitle(newTitle);
        Assert.Equal(newTitle, dvd.getTitle());
    }

    [Fact]
    public void DVD_SetAuthor_ValidAuthor()
    {
        string newAuthor = "New DVD Author";
        dvd.setAuthor(newAuthor);
        Assert.Equal(newAuthor, dvd.getAuthor());
    }

    [Fact]
    public void DVD_SetRunTime_ValidRunTime()
    {
        int newRunTime = 180;
        dvd.setRunTime(newRunTime);
        Assert.Equal(newRunTime, dvd.getRunTime());
    }
}

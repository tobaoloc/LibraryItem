using LibraryItem;

namespace LibraryItemTests
{
    public class LibraryItemTests
    {
        private Book book;
        private DVDs dvd;

        public LibraryItemTests()
        {
            book = new Book("Test Book", "Test Author", true, new DateOnly(2021, 1, 1), "Test Genre");
            dvd = new DVDs("Test DVD", "Test Director", true, new DateOnly(2022, 2, 2), 120);
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
        public void Book_SetTitle_ValidTitle()
        {
            string newTitle = "New Book Title";
            book.setTitle(newTitle);
            Assert.Equal(newTitle, book.getTitle());
        }

        [Fact]
        public void DVD_SetTitle_ValidTitle()
        {
            string newTitle = "New DVD Title";
            dvd.setTitle(newTitle);
            Assert.Equal(newTitle, dvd.getTitle());
        }

        [Fact]
        public void Book_SetAuthor_ValidAuthor()
        {
            string newAuthor = "New Author";
            book.setAuthor(newAuthor);
            Assert.Equal(newAuthor, book.getAuthor());
        }

        [Fact]
        public void DVD_SetAuthor_ValidAuthor()
        {
            string newDirector = "New Director";
            dvd.setAuthor(newDirector);
            Assert.Equal(newDirector, dvd.getAuthor());
        }

        [Fact]
        public void Book_SetGenre_ValidGenre()
        {
            string newGenre = "New Genre";
            book.setGenre(newGenre);
            Assert.Equal(newGenre, book.getGenre());
        }

        [Fact]
        public void DVD_SetRunTime_ValidRunTime()
        {
            int newRunTime = 180;
            dvd.setRunTime(newRunTime);
            Assert.Equal(newRunTime, dvd.getRunTime());
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

            Assert.Contains("Found an items:", consoleOutput);
        }

        [Fact]
        public void LibraryCatalog_FindItem_ByAuthor()
        {
            LibraryCatalog catalog = new LibraryCatalog();
            catalog.AddItem(book);

            var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Test Author"));

            Assert.Contains("Found an items:", consoleOutput);
        }

        [Fact]
        public void LibraryCatalog_FindItem_NotFound()
        {
            LibraryCatalog catalog = new LibraryCatalog();

            var consoleOutput = CaptureConsoleOutput(() => catalog.FindItem("Nonexistent Item"));

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
}

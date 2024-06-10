using LibraryItem;

namespace LibraryTesting
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyContructor_SetDefaultBook()
        {
            var book = new Book();

            // Act
            var genre = book.getGenre();

            // Assert
            Assert.Equal("Default Genre", genre);
        }
    }
}
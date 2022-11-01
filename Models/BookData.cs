namespace Hanc_Darius_Lab2.Models
{
    public class BookData
    {
        public IEnumerable<Bookcs> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }
    }
}

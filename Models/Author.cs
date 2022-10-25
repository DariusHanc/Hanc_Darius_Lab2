namespace Hanc_Darius_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Bookcs>? Books { get; set; }
    }
}

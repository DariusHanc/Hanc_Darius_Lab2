namespace Hanc_Darius_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Bookcs>? Books { get; set; }
    }
}

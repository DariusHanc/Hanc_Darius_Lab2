﻿namespace Hanc_Darius_Lab2.Models
{
    public class BookCategory
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public Bookcs Book { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

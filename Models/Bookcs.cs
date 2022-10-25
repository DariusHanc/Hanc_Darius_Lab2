using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Hanc_Darius_Lab2.Models
{
    public class Bookcs
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]

        public string Title { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; } //cheie straina pentru publisher

        public Publisher? Publisher { get; set; } // navigation catre publiksher
        public Author? Author { get; set;} // navigation catre author
        public int? AuthorID { get; set; } //cheie straina pentru author
    }
}

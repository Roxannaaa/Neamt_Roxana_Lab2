using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace Neamt_Roxana_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(6, 2)")
        [Range(0.01, 500)]

        public string Title { get; set; }
        

        public decimal Price { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; }//navigation property
        
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }//navigation property

        public ICollection<BookCategory>? BookCategories { get; set; }


    }
}

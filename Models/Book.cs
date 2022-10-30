﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Security.Policy;

namespace Neamt_Roxana_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }//navigation property

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }//navigation property


}
}
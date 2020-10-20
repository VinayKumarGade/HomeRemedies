using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Remedies.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int RemedyTypeId { get; set; }

        [ForeignKey("RemedyTypeId")]
        public RemedyType RemedyType { get; set; }

    }
}

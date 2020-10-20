using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Remedies.Models
{
    public class RemedyType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Remedy Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

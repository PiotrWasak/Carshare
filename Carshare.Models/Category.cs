using System;
using System.ComponentModel.DataAnnotations;

namespace Carshare.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
    }
}
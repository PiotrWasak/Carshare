using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Carshare.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Description { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }
        public String ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FakeAPIMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price is not a valid number")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
    }

}
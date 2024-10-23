using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAPIMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public float Price { get; set; }
        string? Description { get; set; }
        
        public string Image { get; set; }
    }

}
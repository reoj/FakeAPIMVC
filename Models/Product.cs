using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAPIMVC.Models
{
    public class Product
    {
        int id { get; set; }
        string title { get; set; }
        float price { get; set; }
        string description { get; set; }
        Category category { get; set; }
        List<string> images { get; set; }
    }

    public class Category
    {
        int id { get; set; }
        string name { get; set; }
        string image { get; set; }  
    }
}
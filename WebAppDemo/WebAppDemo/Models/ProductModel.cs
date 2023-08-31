using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDemo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Category { get; set; }
    }
}
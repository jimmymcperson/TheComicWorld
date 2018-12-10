using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheComicWorld.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Product Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Year Details")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please enter Author Details")]
        public string Author { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify Category")]
        public string Category { get; set; }        
    }
}

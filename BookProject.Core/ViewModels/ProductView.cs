using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Core.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile ImageUrl { get; set; }

        public string CategoryView { get;set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

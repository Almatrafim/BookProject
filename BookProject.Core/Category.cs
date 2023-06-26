using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Core
{
    public class Category
    {
        [Required(ErrorMessage = "{0} is required")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3,
 ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]

        public string name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string description { get; set; }
    }
}

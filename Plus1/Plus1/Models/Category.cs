using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual SubSubCategory Child { get; set; }
    }
}
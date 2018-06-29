using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class SubCategory
    {
        [Key]
        public string Name { get; set; }

        public string ParentName { get; set; }
        public virtual Category Parent { get; set; }
    }
}
using Plus1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Areas.Admin.Models
{
    public class SiteSettings
    {
        public Product EAN { get; set; }
        public bool Visible { get; set; }
    }
}
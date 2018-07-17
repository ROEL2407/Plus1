using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class NewsArticle
    {
    
        public int NewsArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class NewsArticle
    {
        [Key]
        public int ArticleID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
    }
}
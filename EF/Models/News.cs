using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.EF.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int  C_Id { get; set; }
        public DateTime date { get; set; }

        public virtual Category Category { get; set; }
    }
}
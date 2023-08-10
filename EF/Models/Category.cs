using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<News> News { get; set; }
        public Category()
        {
            News = new List<News>();
        }
    }
}
using System.Collections.Generic;

namespace ThoughtsListener.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
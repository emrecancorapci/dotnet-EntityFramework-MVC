using System.Collections;
using System.Collections.Generic;

namespace Bookshop.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
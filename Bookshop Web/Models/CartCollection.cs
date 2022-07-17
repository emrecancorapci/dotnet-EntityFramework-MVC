using System.Collections.Generic;
using System.Linq;
using Bookshop.Dtos.Responses;

namespace Bookshop.Web.Models
{
    public class CartItem
    {
        public ProductListResponse Product { get; set; }
        public int Quantity { get; set; }
    }
    public class CartCollection
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void Add(CartItem item)
        {
            var finding = Items.Find(i => i.Product.Id == item.Product.Id);
            if (finding==null)
            {
                Items.Add(item);
            }
            else
            {
                finding.Quantity += item.Quantity;
            }
        }
        public void ClearAll() => Items.Clear();

        public double? GetTotalPrice()
            => Items.Aggregate<CartItem, double?>(0, (current, item)
                => current + item.Product.Price * (1 - item.Product.Discount) * item.Quantity);

        public void Delete(int id) => Items.RemoveAll(i => i.Product.Id == id);
    }
}
namespace Bookshop.Dtos.Responses
{
    public class ProductListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public bool? IsActive { get; set; }
    }
}
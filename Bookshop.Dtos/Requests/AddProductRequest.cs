using System.ComponentModel.DataAnnotations;

namespace Bookshop.Dtos.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage = "Name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Name cannot be shorter than 3 character.")]
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string ImgUrl { get; set; }
    }
}
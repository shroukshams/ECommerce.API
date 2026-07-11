using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOs.BasketDtos
{
    public class BasketItemDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }=default!;
        public string PictureUrl { get; set; }= default!;
        [Range(1, double.MaxValue, ErrorMessage = "Price is required")]
        public decimal Price { get; set; }= default!;
        [Range(1, 50, ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }= default!;
    }
}
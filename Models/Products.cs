using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OnlineShopNV.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public string Image { get; set; }

        [Required]
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public ProductTypes ProductTypes { get; set; }



        public int SpecialTagId { get; set; }

        public SpecialTags SpecialTags { get; set; }


    }
}

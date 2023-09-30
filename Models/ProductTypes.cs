using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopNV.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public string productType { get; set; }
    }
}

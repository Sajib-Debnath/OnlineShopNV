using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopNV.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tag Name")]
        public string Name { get; set; }
    }
}

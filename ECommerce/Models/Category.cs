using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Category")]
        public string Name { get; set; }
    }
}
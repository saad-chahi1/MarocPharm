using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Current
    {
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Current")]
        public string Name { get; set; }
    }
}
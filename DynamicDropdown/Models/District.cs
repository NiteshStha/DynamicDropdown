using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicDropdown.Models
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public virtual Province? Province { get; set; }
    }
}

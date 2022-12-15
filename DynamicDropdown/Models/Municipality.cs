using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicDropdown.Models
{
    [Table("Municipality")]
    public class Municipality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public virtual District? Province { get; set; }
    }
}

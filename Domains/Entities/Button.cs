using System.ComponentModel.DataAnnotations;

namespace Domains.Entities
{
    public class Button : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TimesClicked { get; set; }

        public virtual Category Category { get; set; }
    }
}

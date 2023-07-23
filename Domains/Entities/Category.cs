using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Label { get; set; }

        public ICollection<Button> Buttons { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}

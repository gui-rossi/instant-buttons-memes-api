using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}

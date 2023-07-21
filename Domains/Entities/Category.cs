using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class Category : BaseEntity
    {
        public string Label { get; set; }

        public ICollection<Button> Buttons { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class Button : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

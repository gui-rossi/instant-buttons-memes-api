using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}

using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.VM
{
    public class ButtonVM
    {
        public string Name { get; set; }

        public string File { get; set; }

        public List<Category> Categories { get; set; }
    }
}

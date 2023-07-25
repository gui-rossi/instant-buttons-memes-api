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
        public int Id { get; set; }

        public string Name { get; set; }

        public string File { get; set; }

        public string CategoryId { get; set; }
    }
}

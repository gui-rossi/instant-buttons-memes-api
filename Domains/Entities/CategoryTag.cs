﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities
{
    public class CategoryTag : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Patient : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public int Count { get; set; }
        public string Info { get; set; }

    }
}

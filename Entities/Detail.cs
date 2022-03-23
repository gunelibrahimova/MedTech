using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Detail : Base
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoURL { get; set; }
    }
}

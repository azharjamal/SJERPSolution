using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJERP.Domain.Models
{
    public class ProductImage : Entity
    {
        public string Name { get; set; }

        /* EF Relationship */
        public IEnumerable<Product> Products { get; set; }
    }
}
